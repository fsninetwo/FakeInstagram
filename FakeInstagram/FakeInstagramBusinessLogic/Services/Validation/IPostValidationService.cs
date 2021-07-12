using FakeInstagramEfModels.Entities;
using FakeInstagramViewModels.CreateModels;
using FakeInstagramViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramBusinessLogic.Services.Validation
{
    public interface IPostValidationService
    {
        void ValidateCreatePostTextModel(CreatePostTextModel createPostTextModel);

        void ValidateCreatePostImageModel(CreatePostImageModel createPostImageModel);

        void ValidateSearchText(string search);

        void ValidatePosts(List<Post> posts);
    }
}
