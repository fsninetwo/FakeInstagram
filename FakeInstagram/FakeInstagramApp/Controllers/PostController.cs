using FakeInstagramBusinessLogic.Repositories;
using FakeInstagramViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeInstagramApp.Controllers
{
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
        /// <param name="id"></param>        
        [HttpPost("{id}")]
        public IActionResult Create(Guid id)
        {
            return NoContent();
        }

        /// <summary>
        /// Gets a specific item.
        /// </summary>
        /// <param name="id"></param>        
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            PostViewModel postViewModel = _postRepository.Get(id);
            return new JsonResult(postViewModel);
        }

        /// <summary>
        /// Updates a specific item.
        /// </summary>
        /// <param name="id"></param>        
        [HttpPut("{id}")]
        public IActionResult Update(Guid id)
        {
            return NoContent();
        }

        /// <summary>
        /// Deletes a specific item.
        /// </summary>
        /// <param name="id"></param> 
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return NoContent();
        }
    }
}
