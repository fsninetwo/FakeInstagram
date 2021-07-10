using FakeInstagramBusinessLogic.Converters;
using FakeInstagramBusinessLogic.Providers;
using FakeInstagramBusinessLogic.Repositories;
using FakeInstagramBusinessLogic.Services.Validation;
using FakeInstagramEfModels.Entities;
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
    public class PostService : IPostService
    {
        private readonly IPostRepository _repository;
        private readonly IPostConverter _converter;
        private readonly ICurrentUserProvider _userProvider;
        private readonly IPostValidationService _postValidateService;
        private readonly IUserValidationService _userValidateService;

        public PostService(IPostRepository repository, IPostConverter converter, ICurrentUserProvider userProvider,
            IPostValidationService postValidateService, IUserValidationService userValidateService)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _converter = converter ?? throw new ArgumentNullException(nameof(converter));
            _userProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));
            _postValidateService = postValidateService ?? throw new ArgumentNullException(nameof(postValidateService));
            _userValidateService = userValidateService ?? throw new ArgumentNullException(nameof(userValidateService));
        }

        public void CreatePostTextModel(CreatePostTextModel postTextModel)
        {
            _postValidateService.ValidateCreatePostTextModel(postTextModel);
            User user = _userProvider.GetCurrentUser();
            _userValidateService.UserIsNullValidation(user);
            Post post = _converter.ConvertToPost(postTextModel, user);
            _repository.CreatePost(post);
        }

        public void CreatePostImageModel(CreatePostImageModel postImageModel)
        {
            _postValidateService.ValidateCreatePostImageModel(postImageModel);
            User user = _userProvider.GetCurrentUser();
            _userValidateService.UserIsNullValidation(user);
            Post post = _converter.ConvertToPost(postImageModel, user);
            _repository.CreatePost(post);
        }

        public PostViewModel GetById(Guid id)
        {
            Post post = _repository.GetById(id);
            return _converter.ConvertToPostViewModel(post);
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public void UpdatePostTextModel(UpdatePostTextModel postTextModel)
        {
            Post post = _converter.ConvertToPost(postTextModel);
            _repository.UpdateTextPost(post);
        }

        public void UpdatePostImageModel(UpdatePostImageModel postImageModel)
        {
            Post post = _converter.ConvertToPost(postImageModel);
            _repository.UpdateImagePost(post);
        }

        public List<PostViewModel> GetPostsById(string search)
        {
            _postValidateService.ValidateSearchText(search);
            List<Post> posts = _repository.GetPostsById(search);
            return _converter.ConvertToPostViewModels(posts);
        }
    }
}
