using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumen.Modules.Sdk {
    public class ConfigEntry {
        public string ModuleName { get; set; } = null!;
        public string ConfigKey { get; set; } = null!;
        public string? ConfigValue { get; set; }
    }
}
