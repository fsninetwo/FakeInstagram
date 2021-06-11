using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramEfModels.Entities
{
    public class PicturePost : PostDecorator
    {
        public PicturePost(Post post) : base(post) { }

        public Picture Picture { get; set; }
    }
}
