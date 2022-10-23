using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace Katsu.src.Logger
{
    class ELoggerConfig
    {
        public ELoggerConfig(bool enable)
        {
            if (enable == true)
            {
            }
            else
            {
                return;
            }
        }
    }
}
