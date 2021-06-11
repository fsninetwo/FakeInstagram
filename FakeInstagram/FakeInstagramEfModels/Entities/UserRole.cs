using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramEfModels.Entities
{
    public class UserRole
    {
        [Key, Required] 
        public Guid Id { get; set; }

        [Required] 
        public string Name { get; set; }

        public List<User> Users { get; set; }
    }
}
