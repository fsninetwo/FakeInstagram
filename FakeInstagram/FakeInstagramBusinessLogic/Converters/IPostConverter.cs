using FakeInstagramEfModels.Entities;
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
    public interface IPostConverter
    {
        Post ConvertToPost(CreatePostTextModel postTextModel, User user);

        Post ConvertToPost(CreatePostImageModel postImageModel, User user);

        Post ConvertToPost(UpdatePostTextModel postTextModel);

        Post ConvertToPost(UpdatePostImageModel postImageModel);

        PostViewModel ConvertToPostViewModel(Post Post);

        List<PostViewModel> ConvertToPostViewModels(List<Post> posts);
    }
}
