using FakeInstagramEfModels.Entities;
using FakeInstagramMigrations;
using FakeInstagramViewModels;
using FakeInstagramViewModels.CreateModels;
using FakeInstagramViewModels.UpdateModels;
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

        public void CreatePostTextModel(CreatePostTextModel postTextModel)
        {

            Post post = new Post
            {
                Id = Guid.NewGuid(),
                Header = postTextModel.Header,
                User = _context.Users.Where(user => user.Email.Equals(postTextModel.UserEmail)).FirstOrDefault(),
                PostAttribute = new PostTextAttribute()
                {
                    Id = Guid.NewGuid(),
                    Text = postTextModel.PostTextAttribute.Text
                }
            };
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void CreatePostImageModel(CreatePostImageModel postImageModel)
        {

            Post post = new Post
            {
                Id = Guid.NewGuid(),
                Header = postImageModel.Header,
                User = _context.Users.Where(user => user.Email.Equals(postImageModel.UserLogin)).FirstOrDefault(),
                PostAttribute = new PostImageAttribute()
                {
                    Id = Guid.NewGuid(),
                    Text = postImageModel.PostImageAttribute.Text,
                    Image = new PostImage
                    {
                        Id = Guid.NewGuid(),
                        Name = postImageModel.PostImageAttribute.PostImage.Name,
                        Link = postImageModel.PostImageAttribute.PostImage.Link
                    }
                }
            };
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public PostViewModel Get(Guid id)
        {
            Post post = GetPost(id);
            //PostViewModel postViewModel = new PostViewModel { Id = post.Id };
            return new PostViewModel { Id = post.Id };
        }

        public Post GetPost(Guid id)
        {
            Post post = _context.Posts.Include(p => p.PostAttribute).FirstOrDefault(post => post.Id == id);
            return post;
        }

        public void Delete(Guid id)
        {
            Post post = GetPost(id);
            //post.PostAttributes.Clear();
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }

        public void UpdatePostTextModel(UpdatePostTextModel postTextModel)
        {
            Post post = GetPost(postTextModel.Id);
            post.Header = postTextModel.Header;
            post.User = _context.Users.Where(user => user.Email.Equals(postTextModel.UserEmail)).FirstOrDefault();
            post.Updated = postTextModel.Updated;
            PostTextAttribute postTextAttribute = (PostTextAttribute)post.PostAttribute;
            postTextAttribute.Text = postTextModel.PostTextAttribute.Text;
            post.PostAttribute = postTextAttribute;
            _context.Posts.Update(post);
            _context.SaveChanges();
        }

        public void UpdatePostImageModel(UpdatePostImageModel postImageModel)
        {
            Post post = GetPost(postImageModel.Id);
            post.Header = postImageModel.Header;
            post.User = _context.Users.Where(user => user.Email.Equals(postImageModel.UserEmail)).FirstOrDefault();
            post.Updated = postImageModel.Updated;
            PostImageAttribute postImageAttribute = (PostImageAttribute)post.PostAttribute;
            postImageAttribute.Text = postImageModel.PostImageAttribute.Text;
            postImageAttribute.Image.Name = postImageModel.PostImageAttribute.PostImage.Name;
            postImageAttribute.Image.Link = postImageModel.PostImageAttribute.PostImage.Link;
            post.PostAttribute = postImageAttribute;
            _context.Posts.Update(post);
            _context.SaveChanges();
        }
    }
}
