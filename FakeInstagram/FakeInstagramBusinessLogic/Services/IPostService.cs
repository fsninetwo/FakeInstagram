using FakeInstagramViewModels.CreateModels;
using FakeInstagramViewModels.UpdateModels;
using FakeInstagramViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FakeInstagramBusinessLogic.Services
{
    public interface IPostService
    {
        Task CreatePostTextModel(CreatePostTextModel postTextModel);

        Task CreatePostImageModel(CreatePostImageModel postImageModel);

        Task<PostViewModel> GetPostById(Guid id);

        Task DeletePostById(Guid id);

        Task UpdatePostTextModel(UpdatePostTextModel postTextModel);

        Task UpdatePostImageModel(UpdatePostImageModel postImageModel);

        Task<List<PostViewModel>> GetPostsBySearch(string search);

        Task<List<PostViewModel>> GetPostsBySearchModel(SearchPostModel searchPostModel);
    }
}
