using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;


namespace Katsu.src.DirectoryCreator
{
    class EDirectoryManage
    {
        public static string FindCurrentDirectory = Path.Combine(Environment.CurrentDirectory, "SystemFiles");
        public static string AchieveMappingsDirectory = Path.Combine(FindCurrentDirectory, "Mappings");

        static EDirectoryManage()
        {
            foreach (var dir in new string[] { FindCurrentDirectory, AchieveMappingsDirectory} )
            {
                if (!Directory.Exists(dir))
                {
                    Log.Debug("Directory(s) not found, creating now..");

                    Console.WriteLine("");
                    Directory.CreateDirectory(dir);
                    Log.Information("Created Directory {Dir}", dir);
                }
            }
        }


    }
}
