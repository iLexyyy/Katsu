using Newtonsoft.Json;
using RestSharp;
using System.Net;
using Serilog;
using System.Diagnostics;
using System.IO;

namespace Katsu.src.Mappings
{
    class EMappings
    {
        public string mappingsUri = "https://fortnitecentral.gmatrixgames.ga/api/v1/mappings";

        public EMappings()
        {

            var test = Path.Combine($"{Environment.CurrentDirectory}\\SystemFiles\\Mappings");

            if (Directory.GetFiles(test).Length == 1)
            {
                string[] findName = Directory.GetFiles(test);
                foreach (string name in findName)
                {
                    Log.Information("Mappings {mappings} has already been downloaded.", Path.GetFileName(name));
                    Log.Debug("Mappings path: {mappingsPath}", test);
                }
            }
            else
            {
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

                                    Console.WriteLine("");
                                    Log.Information("Pulled mappings from {url}", i.fileName);

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
                                        Log.Information("Downloading {0} (!)", i.fileName);
                                        downloadMappings.DownloadFile($"{i.url}", $"{test}\\{i.fileName}");

                                        // Line breaker.
                                        Console.WriteLine("");
                                        Log.Information("Downloaded {0} mappings successfully.", i.fileName);
                                        break;
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
                            return;
                        }

                    }
                }
                catch (Exception e) { return; }
            }
        }
    }
}
