using Newtonsoft.Json;
using RestSharp;
using Serilog;
using System.Net;

namespace Katsu.src.Mappings
{
    class EMappingsLoop
    {
        public string mappingsUri = "https://fortnitecentral.gmatrixgames.ga/api/v1/mappings";

        public EMappingsLoop()
        {

            var test = Path.Combine($"{Environment.CurrentDirectory}\\SystemFiles\\Mappings");

            try
            {
                using (var _client = new RestClient(mappingsUri))
                {
                    var _request = new RestRequest(mappingsUri, method: Method.Get);

                    if (mappingsUri.Length > 0)
                    {
                        // Making Webclient
                        WebClient downloadMappings = new WebClient();

                        // Executing
                        var findUrl = _client.Execute(_request);
                        // ---------

                        // Deserialize ?
                        var _serializeFirst = JsonConvert.SerializeObject(findUrl.Content);
                        var EMappingsData = JsonConvert.DeserializeObject<List<Root>>(findUrl.Content);

                        foreach (var i in EMappingsData) // oh WAIT ITS DOWNLOADING THE ANDROID AND WINDOWS
                        {
                            Console.WriteLine(""); // LINE BREAKER.
                            Log.Debug("Mappings folder empty, pulling mappings now from ({url})", mappingsUri);
                            if (i.url[0] != null)
                            {

                                var getFilename = i.fileName;

                                while (i.fileName == i.fileName)
                                {
                                    Log.Information("Checking for mappings change in {0}", mappingsUri);
                                    Thread.Sleep(3000); // dont spam the api haha
                                    if (i.fileName != getFilename)
                                    {
                                        Thread.Sleep(2000);
                                        Log.Information("New mappings detected.");
                                        Thread.Sleep(4000);
                                        using (var _cclient = new RestClient(mappingsUri))
                                        {
                                            var _crequest = new RestRequest(mappingsUri, method: Method.Get);

                                            if (mappingsUri.Length > 0)
                                            {
                                                // Making Webclient
                                                WebClient _downloadMappings = new WebClient();

                                                // Executing
                                                var _findUrl = _client.Execute(_request);
                                                // ---------

                                                // Deserialize ?
                                                var _cserializeFirst = JsonConvert.SerializeObject(findUrl.Content);
                                                var _EMappingsData = JsonConvert.DeserializeObject<List<Root>>(findUrl.Content);

                                                // ---
                                                foreach (var l in _EMappingsData)
                                                {
                                                    if (l.url[0] != null)
                                                    {
                                                        Console.WriteLine("");
                                                        Log.Information("Pulled mappings from {url}", l.fileName);

                                                        var currentDirectory = Environment.CurrentDirectory;
                                                        var GetDir = Path.Combine(currentDirectory, "SystemFiles");
                                                        // C:\Users\oljwo\source\repos\Katsu\Katsu\bin\Debug\net6.0
                                                        DirectoryInfo di = new DirectoryInfo(GetDir);

                                                        if (!di.Exists)
                                                        {
                                                            return;
                                                        }
                                                        else
                                                        {
                                                            Log.Information("Downloading {0} (!)", l.fileName);
                                                            downloadMappings.DownloadFile($"{l.url}", $"{test}\\{l.fileName}");

                                                            // Line breaker.
                                                            Console.WriteLine("");
                                                            Log.Information("Downloaded {0} mappings successfully.", l.fileName);

                                                            Console.WriteLine(""); // LINE BREAK.
                                                            Console.Write("[ONLY IF YOU HAVE FMODEL INSTALLED] Would you like to import the mappings to FModel (y/n) ");

                                                            // FMODEL INPUT

                                                            // getting input
                                                            string? userInput = Console.ReadLine();
                                                            switch (userInput)
                                                            {
                                                                case "y":
                                                                    Console.Write("Please enter your FModel \"data\" path: ");
                                                                    string? userPath = Console.ReadLine();

                                                                    if (userPath == string.Empty)
                                                                    {
                                                                        return;
                                                                    }
                                                                    else
                                                                    {
                                                                        try
                                                                        {
                                                                            Log.Information("Importing to FModel path: {0}", userPath);
                                                                            Thread.Sleep(2000);

                                                                            downloadMappings.DownloadFile($"{l.url}", $"{userPath}\\{l.fileName}");

                                                                            Log.Debug("Imported mappings to FModel.");

                                                                        }
                                                                        catch (Exception e) { Log.Error("ERR {0}", e.Message); }
                                                                    }
                                                                    break;
                                                                case "n":
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        return;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                return;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        Log.Debug("Mappings url not found.");
                        return;
                    }
                }
            }
            catch (Exception e) { return; }
        }
    }
}

