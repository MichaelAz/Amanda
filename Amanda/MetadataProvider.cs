using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Amanda
{
    internal class MetadataProvider
    {
        public string Verb { get; set; }

        public string Route { get; set; }

        public string Name { get; set; }

        public Dictionary<string, string> Parameters { get; set; }

        public string Result { get; set; }
    }
}
