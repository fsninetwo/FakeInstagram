using System;

namespace FakeInstagramViewModels.CreateModels
{
    public class CreatePostImageModel
    {
        public Guid UserId { get; set; }

        public string Header { get; set; }

        public CreatePostImageAttribute PostImageAttribute { get; set; }
    }
}