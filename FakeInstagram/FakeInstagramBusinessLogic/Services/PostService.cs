using FakeInstagramBusinessLogic.Converters;
using FakeInstagramBusinessLogic.Repositories;
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

        public PostService(IPostRepository repository, IPostConverter converter)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _converter = converter ?? throw new ArgumentNullException(nameof(converter));
        }

        public void CreatePostTextModel(CreatePostTextModel postTextModel)
        {

            Post post = _converter.ConvertToPost(postTextModel);
            _repository.Create(post);
        }

        public void CreatePostImageModel(CreatePostImageModel postImageModel)
        {
            Post post = _converter.ConvertToPost(postImageModel);
            _repository.Create(post);
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
    }
}
