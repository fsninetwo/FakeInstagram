using FakeInstagramBusinessLogic.Repositories;
using FakeInstagramBusinessLogic.Services;
using FakeInstagramViewModels;
using FakeInstagramViewModels.CreateModels;
using FakeInstagramViewModels.UpdateModels;
using FakeInstagramViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeInstagramApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
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
