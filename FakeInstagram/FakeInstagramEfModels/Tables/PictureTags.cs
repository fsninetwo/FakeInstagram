using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramEfModels.Tables
{
    class PictureTags
    {
        [Key, Required] public long UserId { get; set; }
        [Key, Required] public long PictureId { get; set; }
    }
}
