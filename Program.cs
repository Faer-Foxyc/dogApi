using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using dogApi.Classes;
using Newtonsoft.Json;

namespace dogApi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WebRequest request = WebRequest.Create($"https://dog.ceo/api/breeds/image/random");
            WebResponse response = request.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());

            var obj = JsonConvert.DeserializeObject<DogApiClass>(streamReader.ReadToEnd());

            try
            {
                if (obj.status == "success")
                {
                    Console.WriteLine($"Status: {obj.status}, Link: {obj.message}");
                    Process.Start(obj.message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
