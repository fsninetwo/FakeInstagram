using FakeInstagramEfModels.Entities;
using FakeInstagramMigrations;
using FakeInstagramViewModels.CreateModels;
using FakeInstagramViewModels.UpdateModels;
using FakeInstagramViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramBusinessLogic.Converters
{
    public class PostConverter : IPostConverter
    {
        private readonly FakeInstagramContext _context;

        public PostConverter(FakeInstagramContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Post ConvertToPost(CreatePostTextModel postTextModel)
        {
            Post post = new Post
            {
                Id = Guid.NewGuid(),
                Header = postTextModel.Header,
                User = _context.Users.Where(user => user.Id == postTextModel.UserId).FirstOrDefault(),
                PostAttribute = new PostTextAttribute()
                {
                    Id = Guid.NewGuid(),
                    Text = postTextModel.PostTextAttribute.Text
                }
            };
            return post;
        }

        public Post ConvertToPost(CreatePostImageModel postImageModel)
        {
            Post post = new Post
            {
                Id = Guid.NewGuid(),
                Header = postImageModel.Header,
                User = _context.Users.Where(user => user.Id == postImageModel.UserId).FirstOrDefault(),
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
            return post;
        }

        public Post ConvertToPost(UpdatePostTextModel postTextModel)
        {
            Post post = new Post
            {
                Id = postTextModel.Id,
                Header = postTextModel.Header,
                PostAttribute = new PostTextAttribute()
                {
                    Id = Guid.NewGuid(),
                    Text = postTextModel.PostTextAttribute.Text
                }
            };
            return post;
        }

        public Post ConvertToPost(UpdatePostImageModel postImageModel)
        {
            Post post = new Post
            {
                Id = postImageModel.Id,
                Header = postImageModel.Header,
                PostAttribute = new PostImageAttribute()
                {
                    Text = postImageModel.PostImageAttribute.Text,
                    Image = new PostImage
                    {
                        Name = postImageModel.PostImageAttribute.PostImage.Name,
                        Link = postImageModel.PostImageAttribute.PostImage.Link
                    }
                }
            };
            return post;
        }

        public PostViewModel ConvertToPostViewModel(Post post)
        {
            return new PostViewModel { Id = post.Id };
        }

    }
}
