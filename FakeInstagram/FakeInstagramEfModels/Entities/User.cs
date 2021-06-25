using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FakeInstagramEfModels.Entities
{
    public class User : Entity
    {
        [Required] 
        public string Email { get; set; }

        [Required, JsonIgnore]
        public string Password { get; set; }

        public Guid Sol { get; set; }

        [Required] 
        public DateTime Created { get; set; } = DateTime.Now;

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public UserStatus UserStatus { get; set; }

        public UserRole UserRole { get; set; }

        public List<Post> Posts { get; set; }
    }
}
