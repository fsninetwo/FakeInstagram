using System;

namespace FakeInstagramViewModels.CreateModels
{
    public class CreatePostImageModel
    {
        public string Header { get; set; }

        public CreatePostImageAttribute PostImageAttribute { get; set; }

        public string UserLogin { get; set; }
    }
}