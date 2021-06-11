using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramEfModels.Tables
{
    public class UserGroup
    {
        [Key, Required] public long Id { get; set; }
        [Required] public string Name { get; set; }
    }
}
