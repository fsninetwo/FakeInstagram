using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramMigrations.CustomEntities
{
    [Keyless]
    public class TopUser
    {
        public Guid UserId { get; set; }

        public int? Likes { get; set; }
    }
}
