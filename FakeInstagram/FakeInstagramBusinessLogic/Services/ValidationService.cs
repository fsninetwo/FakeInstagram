using FakeInstagramViewModels.CreateModels;
using FakeInstagramBusinessLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramBusinessLogic.Services
{
    public class ValidationService : IValidationService
    {
        public void Validate(CreatePostTextModel createPostTextModel)
        {
            if(createPostTextModel == null)
            {
                throw new ArgumentNullException(nameof(createPostTextModel));
            }

            if(string.IsNullOrEmpty(createPostTextModel.Header))
            {
                throw new PostValidationException("Post header is empty");
            }

            if (string.IsNullOrEmpty(createPostTextModel.PostTextAttribute?.Text))
            {
                throw new PostValidationException("Post text is empty");
            }


        }
    }
}
