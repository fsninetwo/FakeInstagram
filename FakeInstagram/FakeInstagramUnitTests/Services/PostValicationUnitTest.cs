using FakeInstagramBusinessLogic.Exceptions;
using FakeInstagramBusinessLogic.Services;
using FakeInstagramBusinessLogic.Services.Validation;
using FakeInstagramViewModels.CreateModels;
using System;
using Xunit;

namespace FakeInstagramUnitTests.Services
{
    public class PostValicationUnitTest
    {
        private readonly PostValidationService postValidationService = new PostValidationService();

        [Fact]
        public void ValidationService_CreatePostTextModel_ThrowsExceptionWhenModelIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => postValidationService.ValidateCreatePostTextModel(null));
        }

        [Fact]
        public void ValidationService_CreatePostTextModel_ThrowsExceptionWhenEmpryHeader()
        {
            CreatePostTextModel createPostModel = new CreatePostTextModel()
            {
                Header = "",
                PostTextAttribute = new CreatePostTextAttribute()
                {
                    Text = "Simple String"
                }
            };

            Assert.Throws<PostValidationException>(() => postValidationService.ValidateCreatePostTextModel(createPostModel));
        }

        [Fact]
        public void ValidationService_ValidateCreatePostTextModel_ThrowsExceptionWhenEmptyPostText()
        {
            CreatePostTextModel createPostModel = new CreatePostTextModel()
            {
                Header = "Simple Header",
                PostTextAttribute = new CreatePostTextAttribute()
                {
                    Text = string.Empty
                }
            };
            Assert.Throws<PostValidationException>(() => postValidationService.ValidateCreatePostTextModel(createPostModel));
        }

        [Fact]
        public void ValidationService_ValidateCreatePostTextModel_Success()
        {
            CreatePostTextModel createPostModel = new CreatePostTextModel()
            {
                Header = "Simple Header",
                PostTextAttribute = new CreatePostTextAttribute()
                {
                    Text = "Simple Text"
                }
            };
            var exception = Record.Exception(() => postValidationService.ValidateCreatePostTextModel(createPostModel));
            Assert.Null(exception);
        }
    }
}
