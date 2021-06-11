using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramEfModels.Entities
{
    public abstract class PostDecorator : Post
    {
        Post post;
        public PostDecorator(Post post) : base()
        {
            this.post = post;
        }
    }
}
