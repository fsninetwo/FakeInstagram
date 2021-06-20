using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramViewModels.UpdateModels
{
    public class UpdatePostTextModel
    {
        public Guid Id { get; set; }

        public string Header { get; set; }

        public UpdatePostTextAttribute PostTextAttribute { get; set; }

        public string UserEmail { get; set; }

        public DateTime Updated { get; set; } = DateTime.Now;
    }
}
