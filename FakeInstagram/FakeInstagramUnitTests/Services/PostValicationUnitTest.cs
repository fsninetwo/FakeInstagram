using FakeInstagramBusinessLogic.Exceptions;
using FakeInstagramBusinessLogic.Services;
using FakeInstagramBusinessLogic.Services.ValidationServices;
using FakeInstagramViewModels.CreateModels;
using System;
using Xunit;

namespace FakeInstagramUnitTests.Services
{
    public class PostValicationUnitTest
    {
        PostValidationService postValidationService = new PostValidationService();

        [Fact]
        public void ValidationService_CreatePostTextModel_InsertNullValue()
        {
            Assert.Throws<ArgumentNullException>(() => postValidationService.ValidateCreatePostTextModel(null));
        }

        [Fact]
        public void ValidationService_CreatePostTextModel_InsertEmpryHeader()
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
        public void ValidationService_CreatePostTextModel_InsertEmpryPostText()
        {
            CreatePostTextModel createPostModel = new CreatePostTextModel()
            {
                Header = "Simple Header",
                PostTextAttribute = new CreatePostTextAttribute()
                {
                    Text = ""
                }
            };
            Assert.Throws<PostValidationException>(() => postValidationService.ValidateCreatePostTextModel(createPostModel));
        }

        [Fact]
        public void ValidationService_CreatePostTextModel_InsertNonEmptyModels()
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
