using FakeInstagramEfModels.Entities;
using FakeInstagramMigrations;
using FakeInstagramViewModels;
using FakeInstagramViewModels.CreateModels;
using FakeInstagramViewModels.UpdateModels;
using FakeInstagramViewModels.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void CreatePost(Post post)
        {
            DateTime currentDate = DateTime.Now;
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
            _context.SaveChanges();
        }

        public Post GetById(Guid id)
        {
            Post post = _context.Posts.Include(p => p.PostAttribute).FirstOrDefault(post => post.Id == id);
            return post;
        }

        public void Delete(Guid id)
        {
            Post post = GetById(id);
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }

        public void UpdateTextPost(Post post)
        {
            Post oldpost = _context.Posts.Where(post => post.Id == post.Id).FirstOrDefault();
            oldpost.Header = post.Header;
            oldpost.Updated = DateTime.Now;
            PostTextAttribute oldAttribute = (PostTextAttribute)oldpost.PostAttribute;
            PostTextAttribute newAttribute = (PostTextAttribute)oldpost.PostAttribute;
            oldAttribute.Text = newAttribute.Text;
            oldpost.PostAttribute = oldAttribute;
            _context.Posts.Update(oldpost);
            _context.SaveChanges();
        }

        public void UpdateImagePost(Post post)
        {
            Post oldpost = _context.Posts.Where(post => post.Id == post.Id).FirstOrDefault();
            oldpost.Header = post.Header;
            oldpost.Updated = DateTime.Now;
            PostImageAttribute oldAttribute = (PostImageAttribute)oldpost.PostAttribute;
            PostImageAttribute newAttribute = (PostImageAttribute)oldpost.PostAttribute;
            oldAttribute.Text = newAttribute.Text;
            oldAttribute.Image.Name = newAttribute.Image.Name;
            oldAttribute.Image.Link = newAttribute.Image.Link;
            oldpost.PostAttribute = oldAttribute;
            _context.Posts.Update(oldpost);
            _context.SaveChanges();
        }

        public List<Post> GetPostsBySearch(string search)
        {
            search = search.ToLower();
            var posts = _context.Posts
                .Include(postUser => postUser.User)
                .Include(postAttribute => postAttribute.PostAttribute)
                .Select(posts => posts);

            posts = posts.Where(post =>
                post.Header.ToLower().Contains(search) ||
                (post.PostAttribute as PostTextAttribute).Text.ToLower().Contains(search) ||
                //(post.PostAttribute as PostImageAttribute).Text.ToLower().Contains(search) ||
                post.User.FirstName.ToLower().Contains(search) ||
                post.User.LastName.ToLower().Contains(search)
            );

            return posts.ToList();
        }
    }
}
