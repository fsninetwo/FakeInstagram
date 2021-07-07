using FakeInstagramViewModels.CreateModels;
using FakeInstagramBusinessLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeInstagramEfModels.Entities;

namespace FakeInstagramBusinessLogic.Services.ValidationServices
{
    public class PostValidationService : IPostValidationService
    {
        public void ValidateCreatePostTextModel(CreatePostTextModel createPostTextModel)
        {
            if(createPostTextModel == null)
            {
                throw new ArgumentNullException(nameof(createPostTextModel));
            }

            if(string.IsNullOrEmpty(createPostTextModel.Header))
            {
                throw new PostValidationException("Post header is empty");
            }

            if (createPostTextModel.PostTextAttribute == null)
            {
                throw new ArgumentNullException(nameof(createPostTextModel));
            }

            if (string.IsNullOrEmpty(createPostTextModel.PostTextAttribute.Text))
            {
                throw new PostValidationException("Post text is empty");
            }
        }

        public void ValidateCreatePostImageModel(CreatePostImageModel createPostImageModel)
        {
            if (createPostImageModel == null)
            {
                throw new ArgumentNullException(nameof(createPostImageModel));
            }

            if (string.IsNullOrEmpty(createPostImageModel.Header))
            {
                throw new PostValidationException("Post header is empty");
            }

            if (createPostImageModel.PostImageAttribute == null)
            {
                throw new ArgumentNullException(nameof(createPostImageModel));
            }

            if (string.IsNullOrEmpty(createPostImageModel.PostImageAttribute.Text))
            {
                throw new PostValidationException("Post text is empty");
            }

            if (createPostImageModel.PostImageAttribute.PostImage == null)
            {
                throw new ArgumentNullException(nameof(createPostImageModel));
            }

            if (string.IsNullOrEmpty(createPostImageModel.PostImageAttribute.PostImage.Name))
            {
                throw new PostValidationException("Post image name is empty");
            }

            if (string.IsNullOrEmpty(createPostImageModel.PostImageAttribute.PostImage.Link))
            {
                throw new PostValidationException("Post image link is empty");
            }

        }
    }
}
