using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramEfModels.Entities
{
    [Table("PostImageAttributes")]
    public class PostImageAttribute : PostTextAttribute
    {
        [Required]
        public PostImage Image { get; set; }
    }
}
