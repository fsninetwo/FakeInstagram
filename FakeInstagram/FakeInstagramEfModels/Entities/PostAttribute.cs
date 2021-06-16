using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramEfModels.Entities
{
    public abstract class PostAttribute : Entity
    {
        public Post Post { get; set; }
    }
}
