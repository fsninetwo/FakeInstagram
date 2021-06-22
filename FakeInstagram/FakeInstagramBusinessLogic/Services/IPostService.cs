using FakeInstagramViewModels;
using FakeInstagramViewModels.CreateModels;
using FakeInstagramViewModels.UpdateModels;
using FakeInstagramViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramBusinessLogic.Services
{
    public interface IPostService
    {
        void CreatePostTextModel(CreatePostTextModel postTextModel);

        void CreatePostImageModel(CreatePostImageModel postImageModel);

        PostViewModel GetById(Guid id);

        void Delete(Guid id);

        void UpdatePostTextModel(UpdatePostTextModel postTextModel);

        void UpdatePostImageModel(UpdatePostImageModel postImageModel);
    }
}
