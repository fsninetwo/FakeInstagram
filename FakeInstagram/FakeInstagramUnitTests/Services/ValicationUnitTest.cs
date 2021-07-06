using FakeInstagramBusinessLogic.Exceptions;
using FakeInstagramBusinessLogic.Services;
using FakeInstagramViewModels.CreateModels;
using System;
using Xunit;

namespace FakeInstagramUnitTests.Services
{
    public class ValicationUnitTest
    {
        ValidationService validationService = new ValidationService();

        [Fact]
        public void ValidationService_CreatePostTextModel_InsertNullValue()
        {
            Assert.Throws<ArgumentNullException>(() => validationService.ValidateUser(null));
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

            Assert.Throws<PostValidationException>(() => validationService.ValidateCreatePostTextModel(createPostModel));
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
            Assert.Throws<PostValidationException>(() => validationService.ValidateCreatePostTextModel(createPostModel));
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
            var exception = Record.Exception(() => validationService.ValidateCreatePostTextModel(createPostModel));
            Assert.Null(exception);
        }
    }
}
