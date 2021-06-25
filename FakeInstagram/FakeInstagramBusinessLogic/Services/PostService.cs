﻿using FakeInstagramBusinessLogic.Converters;
using FakeInstagramBusinessLogic.Providers;
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
        private readonly ICurrentUserProvider _userProvider;

        public PostService(IPostRepository repository, IPostConverter converter, ICurrentUserProvider userProvider)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _converter = converter ?? throw new ArgumentNullException(nameof(converter));
            _userProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));
        }

        public void CreatePostTextModel(CreatePostTextModel postTextModel)
        {
            User user = _userProvider.GetCurrentUser();
            Post post = _converter.ConvertToPost(postTextModel, user);
            _repository.Create(post);
        }

        public void CreatePostImageModel(CreatePostImageModel postImageModel)
        {
            User user = _userProvider.GetCurrentUser();
            Post post = _converter.ConvertToPost(postImageModel, user);
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
