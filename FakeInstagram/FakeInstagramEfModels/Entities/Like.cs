using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramEfModels.Entities
{
    public class Like : Entity
    {
        public Post Post { get; set; }

        public DateTime Created { get; set; }
    }
}
