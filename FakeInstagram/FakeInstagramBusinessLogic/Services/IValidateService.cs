using FakeInstagramViewModels.CreateModels;

namespace FakeInstagramBusinessLogic.Services
{
    public interface IValidateService
    {
        void Validate(CreatePostTextModel createPostTextModel);
    }
}
