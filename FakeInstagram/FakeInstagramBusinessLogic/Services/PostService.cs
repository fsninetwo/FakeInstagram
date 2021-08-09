using FakeInstagramBusinessLogic.Converters;
using FakeInstagramBusinessLogic.Providers;
using FakeInstagramBusinessLogic.Repositories;
using FakeInstagramBusinessLogic.Services.Validation;
using FakeInstagramEfModels.Entities;
using FakeInstagramViewModels.CreateModels;
using FakeInstagramViewModels.UpdateModels;
using FakeInstagramViewModels.ViewModels;
using System;
using System.Collections.Generic;
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

        public async Task CreatePostTextModel(CreatePostTextModel postTextModel)
        {
            _postValidateService.ValidateCreatePostTextModel(postTextModel);
            User user = await _userProvider.GetCurrentUser();
            _userValidateService.UserIsNullValidation(user);
            Post post = _converter.ConvertToPost(postTextModel, user);
            await _repository.CreatePost(post);
        }

        public async Task CreatePostImageModel(CreatePostImageModel postImageModel)
        {
            _postValidateService.ValidateCreatePostImageModel(postImageModel);
            User user = await _userProvider.GetCurrentUser();
            _userValidateService.UserIsNullValidation(user);
            Post post = _converter.ConvertToPost(postImageModel, user);
            await _repository.CreatePost(post);
        }

        public async Task<PostViewModel> GetPostById(Guid id)
        {
            Post post = await _repository.GetPostById(id);
            return _converter.ConvertToPostViewModel(post);
        }

        public async Task DeletePostById(Guid id)
        {
            await _repository.Delete(id);
        }

        public async Task UpdatePostTextModel(UpdatePostTextModel postTextModel)
        {
            Post post = _converter.ConvertToPost(postTextModel);
            await _repository.UpdateTextPost(post);
        }

        public async Task UpdatePostImageModel(UpdatePostImageModel postImageModel)
        {
            Post post = _converter.ConvertToPost(postImageModel);
            await _repository.UpdateImagePost(post);
        }

        public async Task<List<PostViewModel>> GetPostsBySearch(string search)
        {
            _postValidateService.ValidateSearchText(search);
            List<Post> posts = await _repository.GetPostsBySearch(search);
            _postValidateService.ValidatePosts(posts);
            return _converter.ConvertToPostViewModels(posts);
        }

        public async Task<List<PostViewModel>> GetPostsBySearchModel(SearchPostModel searchPostModel)
        {
            _postValidateService.ValidateSearchModel(searchPostModel);
            List<Post> posts = await _repository.GetPostsBySearch(searchPostModel);
            _postValidateService.ValidatePosts(posts);
            return _converter.ConvertToPostViewModels(posts);
        }
    }
}
