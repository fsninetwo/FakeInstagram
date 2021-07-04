using FakeInstagramBusinessLogic.Providers;
using FakeInstagramBusinessLogic.Repositories;
using FakeInstagramBusinessLogic.Services;
using FakeInstagramEfModels.Entities;
using FakeInstagramViewModels;
using FakeInstagramViewModels.CreateModels;
using FakeInstagramViewModels.UpdateModels;
using FakeInstagramViewModels.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
//using FakeInstagramApp.Attributes;

namespace FakeInstagramApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly ICurrentUserProvider _provider;

        public PostController(IPostService postService, ICurrentUserProvider provider)
        {
            _postService = postService;
            _provider = provider;
        }
       
        [HttpPost]
        public IActionResult CreateTextPost(CreatePostTextModel postTextModel)
        {
            _postService.CreatePostTextModel(postTextModel);
            return new OkResult();
        }
      
        [HttpPost]
        public IActionResult CreateImagePost(CreatePostImageModel postImageModel)
        {
            _postService.CreatePostImageModel(postImageModel);
            return new OkResult();
        }
  
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            PostViewModel postViewModel = _postService.GetById(id);
            return new JsonResult(postViewModel);
        }
      
        [HttpPut]
        public IActionResult UpdateTextPost(UpdatePostTextModel postTextModel)
        {
            _postService.UpdatePostTextModel(postTextModel);
            return new OkResult();
        }
      
        [HttpPut]
        public IActionResult UpdateImagePost(UpdatePostImageModel postImageModel)
        {
            _postService.UpdatePostImageModel(postImageModel);
            return new OkResult();
}

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            _postService.Delete(id);
            return new OkResult();
        }
    }
}
