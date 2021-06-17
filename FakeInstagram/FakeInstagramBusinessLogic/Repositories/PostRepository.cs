using FakeInstagramEfModels.Entities;
using FakeInstagramMigrations;
using FakeInstagramViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramBusinessLogic.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly FakeInstagramContext _context;

        public PostRepository(FakeInstagramContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public PostViewModel Get(Guid id)
        {
            Post post = _context.Posts.FirstOrDefault(post => post.Id == id);
            //PostViewModel postViewModel = new PostViewModel { Id = post.Id };
            return new PostViewModel { Id = post.Id };
        }
    }
}
