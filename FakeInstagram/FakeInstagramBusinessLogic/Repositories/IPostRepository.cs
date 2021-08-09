using FakeInstagramEfModels.Entities;
using FakeInstagramViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FakeInstagramBusinessLogic.Repositories
{
    public interface IPostRepository
    {
        Task CreatePost(Post post);

        Task<Post> GetPostById(Guid id);

        Task UpdateTextPost(Post post);

        Task UpdateImagePost(Post post);

        Task Delete(Guid id);

        Task<List<Post>> GetPostsBySearch(string search);

        Task<List<Post>> GetPostsBySearch(SearchPostModel searchPostModel);
    }
}
