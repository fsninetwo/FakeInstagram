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
        public Post ConvertToPost(CreatePostTextModel postTextModel, FakeInstagramEfModels.Entities.User user)
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

        public Post ConvertToPost(CreatePostImageModel postImageModel, FakeInstagramEfModels.Entities.User user)
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

        public List<PostViewModel> ConvertToPostViewModels(List<Post> posts)
        {
            List<PostViewModel> postViewModels = new List<PostViewModel>();

            foreach(Post post in posts)
            {
                PostAttributeViewModel postAttributeViewModel = new PostAttributeViewModel();

                if(post.PostAttribute is PostTextAttribute)
                {
                    postAttributeViewModel.Text = (post.PostAttribute as PostTextAttribute).Text;
                }
                else if (post.PostAttribute is PostImageAttribute)
                {
                    postAttributeViewModel.Text = (post.PostAttribute as PostImageAttribute).Text;
                    postAttributeViewModel.PostImageViewModel = new PostImageViewModel()
                    {
                        Link = (post.PostAttribute as PostImageAttribute).Image.Link,
                        Name = (post.PostAttribute as PostImageAttribute).Image.Name,
                    };
                }

                PostViewModel postViewModel = new PostViewModel()
                { 
                    Id = post.Id,
                    Header = post.Header,
                    PostAttributeViewModel = postAttributeViewModel,
                    UserId = post.User.Id,
                    FirstName = post.User.FirstName,
                    LastName = post.User.LastName
                };
                postViewModels.Add(postViewModel);
            }

            return postViewModels;
        }
    }
}
