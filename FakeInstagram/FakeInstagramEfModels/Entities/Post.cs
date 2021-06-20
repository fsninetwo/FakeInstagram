using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramEfModels.Entities
{
    public class Post : Entity
    {
        [Required]
        public string Header { get; set; }

        [Required]
        public DateTime Created { get; set; } = DateTime.Now;

        [Required]
        public DateTime Updated { get; set; } = DateTime.Now;

        [Required]
        public User User { get; set; }

        [Required]
        public PostAttribute PostAttribute { get; set; }

        public List<Tag> Tags { get; set; }

        public List<Like> Likes { get; set; }
    }
}
