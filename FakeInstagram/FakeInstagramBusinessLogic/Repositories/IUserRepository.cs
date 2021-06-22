using FakeInstagramEfModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramBusinessLogic.Repositories
{
    public interface IUserRepository
    {
        User GetByEmailAndPassword(string email, string password);

        User GetById(Guid id);

        IEnumerable<User> GetAll();
    }
}
