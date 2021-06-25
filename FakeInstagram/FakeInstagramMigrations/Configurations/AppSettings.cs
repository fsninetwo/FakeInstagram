using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramMigrations.Configurations
{
    public class AppSettings : IAppSettings
    {
        public string ConnectionString { get; set; }

        public string Secret { get; set; }
    }
}
