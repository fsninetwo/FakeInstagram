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

namespace FakeInstagramApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }
       
        [HttpPost]
        public async Task<IActionResult> CreateTextPost(CreatePostTextModel postTextModel)
        {
            await _postService.CreatePostTextModel(postTextModel);
            return new OkResult();
        }
      
        [HttpPost]
        public async Task<IActionResult> CreateImagePost(CreatePostImageModel postImageModel)
        {
            await _postService.CreatePostImageModel(postImageModel);
            return new OkResult();
        }
  
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PostViewModel>> GetPost(Guid id)
        {
            PostViewModel postViewModel = await _postService.GetPostById(id);
            return new JsonResult(postViewModel);
        }

        [HttpGet]
        [Route("{search}")]
        public async Task<ActionResult<IEnumerable<PostViewModel>>> GetPostByText(string search)
        {
            IEnumerable <PostViewModel> postViewModel = await _postService.GetPostsBySearch(search);
            return new JsonResult(postViewModel);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostViewModel>>> GetPostBySearchTextModel([FromQuery]SearchPostModel searchPostModel)
        {
            IEnumerable<PostViewModel> postViewModel = await _postService.GetPostsBySearchModel(searchPostModel);
            return new JsonResult(postViewModel);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTextPost(UpdatePostTextModel postTextModel)
        {
            await _postService.UpdatePostTextModel(postTextModel);
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
            _postService.DeletePostById(id);
            return new OkResult();
        }
    }
}
