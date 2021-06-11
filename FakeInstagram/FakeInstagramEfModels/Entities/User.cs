﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramEfModels.Entities
{
    public class User
    {
        [Key, Required] 
        public Guid Id { get; set; }

        [Required] 
        public string Login { get; set; }

        [Required] 
        public string Password { get; set; }

        [Required] 
        public DateTime Created { get; set; } = DateTime.Now;
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UserStatus UserStatus { get; set; }
        public UserRole UserRole { get; set; }

        public List<Post> Posts { get; set; }
    }
}