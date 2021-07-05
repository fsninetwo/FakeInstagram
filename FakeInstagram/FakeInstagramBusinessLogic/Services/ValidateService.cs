using FakeInstagramViewModels.CreateModels;
using FakeInstagramBusinessLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramBusinessLogic.Services
{
    public class ValidateService : IValidateService
    {
        public void Validate(CreatePostTextModel createPostTextModel)
        {
            if(createPostTextModel.Header.Equals("") || createPostTextModel.Header == null)
            {
                throw new PostException("Post header is empty");
            }

            if (createPostTextModel.PostTextAttribute.Text.Equals("") || createPostTextModel.PostTextAttribute.Text == null)
            {
                throw new PostException("Post text is empty");
            }
        }
    }
}
