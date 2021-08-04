using FakeInstagramEfModels.Entities;
using System;
using System.Threading.Tasks;

namespace FakeInstagramBusinessLogic.Providers
{
    public interface ICurrentUserProvider
    {
        Task<User> GetCurrentUser();

        bool IsCurrentUserCreator(Guid userId);
    }
}
