using FakeInstagramViewModels;
using FakeInstagramViewModels.CreateModels;
using FakeInstagramViewModels.UpdateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramBusinessLogic.Repositories
{
    public interface IPostRepository
    {
        void CreatePostTextModel(CreatePostTextModel postTextModel);

        void CreatePostImageModel(CreatePostImageModel postImageModel);

        PostViewModel Get(Guid id);

        void UpdatePostTextModel(UpdatePostTextModel postTextModel);

        void UpdatePostImageModel(UpdatePostImageModel postImageModel);

        void Delete(Guid id);
    }
}
