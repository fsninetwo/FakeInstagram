using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramViewModels.UpdateModels
{
    public class UpdatePostImageModel
    {
        public Guid Id { get; set; }

        public string Header { get; set; }

        public UpdatePostImageAttribute PostImageAttribute { get; set; }
    }
}
