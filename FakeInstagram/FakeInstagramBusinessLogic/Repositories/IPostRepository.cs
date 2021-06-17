using FakeInstagramViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramBusinessLogic.Repositories
{
    public interface IPostRepository
    {
        PostViewModel Get(Guid id);
    }
}
