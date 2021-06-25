using System;

namespace FakeInstagramViewModels.CreateModels
{
    public class CreatePostTextModel
    {
        public string Header { get; set; }

        public CreatePostTextAttribute PostTextAttribute { get; set; }
    }
}