﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramEfModels.Entities
{
    public class UsualPost : Post
    {
        [Key, Required]
        public Guid Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime Created { get; set; } = DateTime.Now;

        [Required]
        public DateTime Updated { get; set; } = DateTime.Now;

        public User User { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
