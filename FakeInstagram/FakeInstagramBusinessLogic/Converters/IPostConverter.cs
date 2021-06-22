using FakeInstagramEfModels.Entities;
using FakeInstagramViewModels.CreateModels;
using FakeInstagramViewModels.UpdateModels;
using FakeInstagramViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramBusinessLogic.Converters
{
    public interface IPostConverter
    {
        Post ConvertToPost(CreatePostTextModel postTextModel);

        Post ConvertToPost(CreatePostImageModel postImageModel);

        Post ConvertToPost(UpdatePostTextModel postTextModel);

        Post ConvertToPost(UpdatePostImageModel postImageModel);

        PostViewModel ConvertToPostViewModel(Post Post);
    }
}
