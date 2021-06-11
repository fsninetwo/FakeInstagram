﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramEfModels.Entities
{
    public enum PostStatus
    {
        Idle = 0,
        Pinned,
        Warned,
        Suspended,
        Banned,
        Deleted
    }
}