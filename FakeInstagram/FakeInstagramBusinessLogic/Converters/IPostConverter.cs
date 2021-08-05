using FakeInstagramEfModels.Entities;
using FakeInstagramViewModels.CreateModels;
using FakeInstagramViewModels.UpdateModels;
using FakeInstagramViewModels.ViewModels;
using System.Collections.Generic;

namespace FakeInstagramBusinessLogic.Converters
{
    public interface IPostConverter
    {
        Post ConvertToPost(CreatePostTextModel postTextModel, FakeInstagramEfModels.Entities.User user);

        Post ConvertToPost(CreatePostImageModel postImageModel, FakeInstagramEfModels.Entities.User user);

        Post ConvertToPost(UpdatePostTextModel postTextModel);

        Post ConvertToPost(UpdatePostImageModel postImageModel);

        PostViewModel ConvertToPostViewModel(Post Post);

        List<PostViewModel> ConvertToPostViewModels(List<Post> posts);
    }
}
