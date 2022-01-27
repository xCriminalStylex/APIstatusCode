using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace APIstatusCode
{
    class Program
    {
        static void Main(string[] args)
        {
            
                string url = "http://api.openweathermap.org/data/2.5/find?q=London&units=metric&appid=c306ad20e3d780a22a50e7dd23900d02";
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                System.Threading.Thread.Sleep(10000);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                System.Threading.Thread.Sleep(10000);
                string response;
                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                }
                JsonFileResponse jsonFileResponse = JsonConvert.DeserializeObject<JsonFileResponse>(response);
                Console.WriteLine($"Status message:{jsonFileResponse.Message}");
                Console.WriteLine($"Status code:{jsonFileResponse.Cod}");


        }
    }
}
