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
    [Route("[controller]/[action]")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        /// <summary>
        /// Creates a specific item.
        /// </summary>
        /// <param name="postTextModel"></param>        
        [HttpPost]
        public IActionResult CreateTextPost(CreatePostTextModel postTextModel)
        {
            _postService.CreatePostTextModel(postTextModel);
            return new OkResult();
        }

        /// <summary>
        /// Creates a specific item.
        /// </summary>
        /// <param name="postImageModel"></param>        
        [HttpPost]
        public IActionResult CreateImagePost(CreatePostImageModel postImageModel)
        {
            _postService.CreatePostImageModel(postImageModel);
            return new OkResult();
        }

        /// <summary>
        /// Gets a specific item.
        /// </summary>
        /// <param name="id"></param>        
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            PostViewModel postViewModel = _postService.Get(id);
            return new JsonResult(postViewModel);
        }

        /// <summary>
        /// Updates a specific item.
        /// </summary>
        /// <param name="postTextModel"></param>      
        [HttpPut]
        public IActionResult UpdateTextPost(UpdatePostTextModel postTextModel)
        {
            _postService.UpdatePostTextModel(postTextModel);
            return new OkResult();
        }

        /// <summary>
        /// Updates a specific item.
        /// </summary>
        /// <param name="postImageModel"></param>      
        [HttpPut]
        public IActionResult UpdateImagePost(UpdatePostImageModel postImageModel)
        {
            _postService.UpdatePostImageModel(postImageModel);
            return new OkResult();
        }

        /// <summary>
        /// Deletes a specific item.
        /// </summary>
        /// <param name="id"></param> 
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            _postService.Delete(id);
            return new OkResult();
        }
    }
}
