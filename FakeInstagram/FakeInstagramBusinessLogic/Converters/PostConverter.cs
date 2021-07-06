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
        public Post ConvertToPost(CreatePostTextModel postTextModel, User user)
        {
            Post post = new Post
            {
                Header = postTextModel.Header,
                User = user,
                PostAttribute = new PostTextAttribute()
                {
                    Text = postTextModel.PostTextAttribute.Text
                }
            };
            return post;
        }

        public Post ConvertToPost(CreatePostImageModel postImageModel, User user)
        {
            Post post = new Post
            {
                Header = postImageModel.Header,
                User = user,
                PostAttribute = new PostImageAttribute()
                {
                    Text = postImageModel.PostImageAttribute.Text,
                    Image = new PostImage
                    {
                        Name = postImageModel.PostImageAttribute.PostImage.Name,
                        Link = postImageModel.PostImageAttribute.PostImage.Link,
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
