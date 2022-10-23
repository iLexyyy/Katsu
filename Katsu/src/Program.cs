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
using Spectre.Console;

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

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[blue]What would you like to do?[/]")
                    .HighlightStyle("45")
                    .MoreChoicesText("[grey](Move up and down to see more options)[/]")
                    .AddChoices(new[]
                    {
                        "Download Mappings",
                        "Loop through Mappings"
                    }));


            if (choice == "Download Mappings")
            {
                EMappings DownloadLatestMappings = new EMappings();
            }
            else if (choice == "Loop through Mappings")
            {
                EMappingsLoop LoopThrough = new EMappingsLoop();
            }

            // Strings
            var executable = "executable";
            var program = "program";
            var finish = "Done";


            // Console.WriteLine(""); LINE BREAKER!
            Log.Debug("{finish}. You may now close this {pro} / {exe}", finish, program, executable); // simple enough.

        }
    }
}