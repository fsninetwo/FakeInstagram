using FakeInstagramBusinessLogic.Extensions;
using FakeInstagramEfModels.Entities;
using FakeInstagramMigrations;
using FakeInstagramViewModels.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace FakeInstagramBusinessLogic.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly FakeInstagramContext _context;

        public PostRepository(FakeInstagramContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CreatePost(Post post)
        {
            var currentDate = DateTime.Now;
            post.Id = Guid.NewGuid();
            post.PostAttribute.Id = Guid.NewGuid();
            post.Created = currentDate;
            if (post.PostAttribute is PostImageAttribute attribute)
            {
                attribute.Image.Id = Guid.NewGuid();
                attribute.Image.Uploaded = currentDate;
                post.PostAttribute = attribute;
            }
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task<Post> GetPostById(Guid id)
        {
            var post = await _context.Posts.Include(p => p.PostAttribute).FirstOrDefaultAsync(postId => postId.Id == id);
            return post;
        }

        public async Task Delete(Guid id)
        {
            var post = await GetPostById(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTextPost(Post post)
        {
            Post oldpost = await _context.Posts.FirstOrDefaultAsync(posts => posts.Id == post.Id);
            oldpost.Header = post.Header;
            oldpost.Updated = DateTime.Now;
            PostTextAttribute oldAttribute = (PostTextAttribute)oldpost.PostAttribute;
            PostTextAttribute newAttribute = (PostTextAttribute)oldpost.PostAttribute;
            oldAttribute.Text = newAttribute.Text;
            oldpost.PostAttribute = oldAttribute;
            _context.Posts.Update(oldpost);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateImagePost(Post post)
        {
            Post oldpost = await _context.Posts.FirstOrDefaultAsync(posts => posts.Id == post.Id);
            oldpost.Header = post.Header;
            oldpost.Updated = DateTime.Now;
            PostImageAttribute oldAttribute = (PostImageAttribute)oldpost.PostAttribute;
            PostImageAttribute newAttribute = (PostImageAttribute)oldpost.PostAttribute;
            oldAttribute.Text = newAttribute.Text;
            oldAttribute.Image.Name = newAttribute.Image.Name;
            oldAttribute.Image.Link = newAttribute.Image.Link;
            oldpost.PostAttribute = oldAttribute;
            _context.Posts.Update(oldpost);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Post>> GetPostsBySearch(string search)
        {
            search = search.ToLower();
            var posts = _context.Posts
                .Include(postUser => postUser.User)
                .Include(postAttribute => postAttribute.PostAttribute)
                .Select(searchPosts => searchPosts);

            posts = posts.Where(post => 
                post.Header.ToLower().Contains(search) ||
                ((post.PostAttribute is PostTextAttribute) && (post.PostAttribute as PostTextAttribute).Text.ToLower().Contains(search)) ||
                //(post.PostAttribute as PostImageAttribute).Text.ToLower().Contains(search) ||
                post.User.FirstName.ToLower().Contains(search) ||
                post.User.LastName.ToLower().Contains(search)
            );

            //var query = posts.ToQueryString();

            return await posts.ToListAsync();
        }

        public async Task<List<Post>> GetPostsBySearch(SearchPostModel searchPostModel)
        {
            var posts = _context.Posts
                .Include(postUser => postUser.User)
                .Include(postAttribute => postAttribute.PostAttribute)
                .Select(searchPosts => searchPosts);

            if (!string.IsNullOrEmpty(searchPostModel.Header))
            {
                posts = posts.Where(post => post.Header.ToLower().Contains(searchPostModel.Header.ToLower()));
            }

            if (!string.IsNullOrEmpty(searchPostModel.Text))
            {
                var predicate = PredicateBuilder.False<Post>();

                predicate = predicate.Or(p => p.PostAttribute is PostTextAttribute && 
                    ((PostTextAttribute) p.PostAttribute).Text.ToLower().Contains(searchPostModel.Text.ToLower()));
                predicate = predicate.Or(p => p.PostAttribute is PostImageAttribute && 
                    ((PostImageAttribute) p.PostAttribute).Text.ToLower().Contains(searchPostModel.Text.ToLower()));
                posts = posts.Where(predicate);
            }

            if (!string.IsNullOrEmpty(searchPostModel.FirstName))
            {
                posts = posts.Where(post => post.User.FirstName.ToLower().Contains(searchPostModel.FirstName.ToLower()));
            }

            if (!string.IsNullOrEmpty(searchPostModel.LastName))
            {
                posts = posts.Where(post => post.User.LastName.ToLower().Contains(searchPostModel.LastName.ToLower()));
            }

            //var query = posts.ToQueryString();

            return await posts.ToListAsync();
        }
    }
}
