using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katsu.src.Mappings
{
        public class Meta
        {
            public string version { get; set; }
            public string compressionMethod { get; set; }
            public string platform { get; set; }
        }

        public class Root
        {
            public string ? url { get; set; }
            public string fileName { get; set; }
            public string hash { get; set; }
            public int length { get; set; }
            public DateTime uploaded { get; set; }
            public Meta meta { get; set; }
        }
}
