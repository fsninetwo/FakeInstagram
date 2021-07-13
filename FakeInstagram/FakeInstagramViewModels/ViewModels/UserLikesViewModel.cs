using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramViewModels.ViewModels
{
    public class UserLikesViewModel
    {
        public Guid UserId { get; set; }

        public int AvgCount { get; set; }
    }
}
