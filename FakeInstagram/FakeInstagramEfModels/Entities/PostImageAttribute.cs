using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramEfModels.Entities
{
    public class PostImageAttribute : PostTextAttribute
    {
        [Required]
        public PostImage Image { get; set; }

    }
}
