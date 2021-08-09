using FakeInstagramEfModels.Entities;
using FakeInstagramViewModels.CreateModels;
using FakeInstagramViewModels.ViewModels;
using System.Collections.Generic;

namespace FakeInstagramBusinessLogic.Services.Validation
{
    public interface IPostValidationService
    {
        void ValidateCreatePostTextModel(CreatePostTextModel createPostTextModel);

        void ValidateCreatePostImageModel(CreatePostImageModel createPostImageModel);

        void ValidateSearchText(string search);

        void ValidateSearchModel(SearchPostModel searchPostModel);

        void ValidatePosts(List<Post> posts);

    }
}
