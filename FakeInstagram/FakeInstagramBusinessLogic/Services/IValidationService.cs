using FakeInstagramEfModels.Entities;
using FakeInstagramViewModels.CreateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramBusinessLogic.Services
{
    public interface IValidationService
    {
        void ValidateCreatePostTextModel(CreatePostTextModel createPostTextModel);

        void ValidateCreatePostImageModel(CreatePostImageModel createPostImageModel);

        void ValidateUser(User user);
    }
}
