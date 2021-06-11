using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramEfModels.Tables
{
    public class Picture
    {
        [Key, Required] public long Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Link { get; set; }
        [Required] public string Context { get; set; }
        [Required] public DateTime Uploaded { get; set; } = DateTime.Now;
    }
}
