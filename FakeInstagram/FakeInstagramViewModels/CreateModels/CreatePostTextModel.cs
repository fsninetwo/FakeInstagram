using System;

namespace FakeInstagramViewModels.CreateModels
{
    public class CreatePostTextModel
    {
        public Guid UserId { get; set; }

        public string Header { get; set; }

        public CreatePostTextAttribute PostTextAttribute { get; set; }
    }
}