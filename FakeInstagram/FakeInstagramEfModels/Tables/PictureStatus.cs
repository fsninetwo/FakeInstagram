using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramEfModels.Tables
{
    class PictureStatus
    {
        [Key, Required] public long Id { get; set; }
        [Required] public string Name { get; set; }
    }
}
