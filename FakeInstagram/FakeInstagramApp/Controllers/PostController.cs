using FakeInstagramBusinessLogic.Repositories;
using FakeInstagramViewModels;
using FakeInstagramViewModels.CreateModels;
using FakeInstagramViewModels.UpdateModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeInstagramApp.Controllers
{
    [Route("[controller]")]
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        /// <summary>
        /// Creates a specific item.
        /// </summary>
        /// <param name="postTextModel"></param>        
        [HttpPost]
        [Route("CreateTextPost/")]
        public IActionResult CreateTextPost(CreatePostTextModel postTextModel)
        {
            _postRepository.CreatePostTextModel(postTextModel);
            return new OkResult();
        }

        /// <summary>
        /// Creates a specific item.
        /// </summary>
        /// <param name="postImageModel"></param>        
        [HttpPost]
        [Route("CreateImagePost/")]
        public IActionResult CreateTextPost(CreatePostImageModel postImageModel)
        {
            _postRepository.CreatePostImageModel(postImageModel);
            return new OkResult();
        }

        /// <summary>
        /// Gets a specific item.
        /// </summary>
        /// <param name="id"></param>        
        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult Get(Guid id)
        {
            PostViewModel postViewModel = _postRepository.Get(id);
            return new JsonResult(postViewModel);
        }

        /// <summary>
        /// Updates a specific item.
        /// </summary>
        /// <param name="postTextModel"></param>      
        [HttpPut]
        [Route("UpdatePostTextModel/")]
        public IActionResult UpdateTextPost(UpdatePostTextModel postTextModel)
        {
            _postRepository.UpdatePostTextModel(postTextModel);
            return new OkResult();
        }

        /// <summary>
        /// Updates a specific item.
        /// </summary>
        /// <param name="postImageModel"></param>      
        [HttpPut]
        [Route("UpdatePostImageModel/")]
        public IActionResult UpdateImagePost(UpdatePostImageModel postImageModel)
        {
            _postRepository.UpdatePostImageModel(postImageModel);
            return new OkResult();
        }

        /// <summary>
        /// Deletes a specific item.
        /// </summary>
        /// <param name="id"></param> 
        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            _postRepository.Delete(id);
            return new OkResult();
        }
    }
}
