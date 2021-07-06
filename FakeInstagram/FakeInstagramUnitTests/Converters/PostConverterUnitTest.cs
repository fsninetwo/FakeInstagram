using FakeInstagramBusinessLogic.Converters;
using FakeInstagramEfModels.Entities;
using FakeInstagramViewModels.CreateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FakeInstagramUnitTests.Converters
{
    public class PostConverterUnitTest
    {
        PostConverter postConverter = new PostConverter();

        [Fact]
        public void PostConverter_ConvertPostTextModel_ReturnAllFields()
        {
            CreatePostTextModel createPostModel = new CreatePostTextModel()
            {

                Header = "Simple String",
                PostTextAttribute = new CreatePostTextAttribute()
                {
                    Text = "Simple String"
                }
            };

            Post expected = new Post()
            {
                Header = "Simple String",
                PostAttribute = new PostTextAttribute()
                {
                    Text = "Simple String"
                }
            };

            var actual = postConverter.ConvertToPost(createPostModel, null);

            Assert.Equal(expected.Header, actual.Header);
            var expectedAttribute = (PostTextAttribute)expected.PostAttribute;
            var actualAttribute = (PostTextAttribute)actual.PostAttribute;

            Assert.Equal(expectedAttribute.Text, actualAttribute.Text);
        }

        [Fact]
        public void PostConverter_ConvertPostImageModel_ReturnAllFields()
        {
     
            CreatePostImageModel createPostModel = new CreatePostImageModel()
            {
                Header = "Simple String",
                PostImageAttribute = new CreatePostImageAttribute()
                {
                    Text = "Simple String",
                    PostImage = new CreatePostImage()
                    {
                        Link = "Link",
                        Name = "Name",
                    }
                }
            };

            Post expected = new Post()
            {
                Header = "Simple String",
                PostAttribute = new PostImageAttribute()
                {
                    Text = "Simple String",
                    Image = new PostImage()
                    {
                        Link = "Link",
                        Name = "Name",
                    }
                }
            };

            var actual = postConverter.ConvertToPost(createPostModel, null);

            Assert.Equal(expected.Header, actual.Header);
            var expectedAttribute = (PostImageAttribute)expected.PostAttribute;
            var actualAttribute = (PostImageAttribute)actual.PostAttribute;

            Assert.Equal(expectedAttribute.Text, actualAttribute.Text);
            Assert.Equal(expectedAttribute.Image.Name, actualAttribute.Image.Name);
            Assert.Equal(expectedAttribute.Image.Link, actualAttribute.Image.Link);
        }
    }
}
