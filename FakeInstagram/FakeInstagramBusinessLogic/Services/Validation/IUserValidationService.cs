﻿using FakeInstagramEfModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramBusinessLogic.Services.Validation
{
    public interface IUserValidationService
    {
        void UserIsNullValidation(User user);
    }
}
