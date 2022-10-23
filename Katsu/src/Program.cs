using System.IO;
using System;
using Serilog;
using Newtonsoft.Json;
using Newtonsoft;
using RestSharp;
using Serilog.Sinks.SystemConsole.Themes;
using Katsu.src.Logger;
using Katsu.src.DirectoryCreator;
using Katsu.src.Mappings;

namespace Katsu
{
    class Program
    {
        public static void Main()
        {

            // Enabling / Not-Enabling Logger.
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(theme: SystemConsoleTheme.Literate)
                .MinimumLevel.Debug()
                .CreateLogger();
            // ------------------------------

            EDirectoryManage EDirectoryCreator = new EDirectoryManage();
            // ?

            EMappings DownloadLatestMappings = new EMappings();

            // Strings
            var executable = "executable";
            var program = "program";
            var finish = "Done";


            // Console.WriteLine(""); LINE BREAKER!
            Log.Debug("{finish}. You may now close this {pro} / {exe}", finish, program, executable); // simple enough.

        }
    }
}