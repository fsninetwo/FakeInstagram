using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramEfModels.Entities
{
    [Table("PostTextAttributes")]
    public class PostTextAttribute : PostAttribute
    {
        public string Text { get; set; }

        public Post Post { get; set; }
    }
}
