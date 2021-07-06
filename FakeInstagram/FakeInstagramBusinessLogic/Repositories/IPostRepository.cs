using FakeInstagramEfModels.Entities;
using FakeInstagramViewModels;
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
        void CreatePost(Post post);

        Post GetById(Guid id);

        void UpdateTextPost(Post post);

        void UpdateImagePost(Post post);

        void Delete(Guid id);
    }
}
