using FakeInstagramEfModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramViewModels.ViewModels
{
    public class PostViewModel
    {
        public Guid Id { get; set; }

        public string Header { get; set; }

        public PostAttribute PostAttribute { get; set; }

        public Guid UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
