﻿using FakeInstagramViewModels.CreateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramBusinessLogic.Services
{
    public interface IValidateService
    {
        void Validate(CreatePostTextModel createPostTextModel);
    }
}
