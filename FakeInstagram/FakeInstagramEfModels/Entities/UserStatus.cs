using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramEfModels.Entities
{
    public enum UserStatus
    {
        Idle = 0,
        Warned,
        Suspended,
        Banned,
        Deleted
    }
}
