using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KrisInfo
{
    public class KrisInfo
    {
        public static async Task GetJsonDataAll()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.krisinformation.se");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("/v3/news");
            if (response.IsSuccessStatusCode)
            {
                // Gör om responsen till en sträng
                var responseBody = await response.Content.ReadAsStringAsync();
                try
                {
                    // Gör om strängen till vår egen skapade datatyp - KrisInfoResponse
                    var messages = JsonConvert.DeserializeObject<List<KrisInfoResponse>>(responseBody);
                    if (messages != null)
                    {
                        Console.WriteLine("Samtliga Varningar");
                        Console.WriteLine("******************");
                        foreach (var message in messages)
                        {
                            Console.WriteLine($"Id: {message.Identifier}");
                            Console.WriteLine($"Message: {message.PushMessage}");
                            Console.WriteLine($"Published: {message.Published}");
                            Console.WriteLine($"Country: {message.Area[0].Description}");
                            Console.WriteLine("========================================");
                        }
                    }

                    Console.WriteLine("Tryck valfri knapp för att fortsätta");
                    Console.ReadLine();
                }
                catch (JsonReaderException)
                {
                    Console.WriteLine("Prutt! Det funkade inte.");
                }
            }
        }

        public static async Task GetJsonDataOne(int id)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.krisinformation.se");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync($"/v3/news/{id}");
            if (!response.IsSuccessStatusCode)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Id hittades ej!");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Tryck valfri knapp för att fortsätta");
                Console.ReadLine();
            }
            
            else if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                try
                {
                    var message = JsonConvert.DeserializeObject<KrisInfoResponse>(responseBody);
                    if (message != null)
                    {
                        Console.WriteLine("En Varning");
                        Console.WriteLine("**********");
                        Console.WriteLine($"Id: {message.Identifier}");
                        Console.WriteLine($"Message: {message.PushMessage}");
                        Console.WriteLine($"Published: {message.Published}");
                        Console.WriteLine($"Country: {message.Area[0].Description}");
                        Console.WriteLine("========================================");
                    }
                    Console.WriteLine("Tryck valfri knapp för att fortsätta");
                    Console.ReadLine();
                }
                catch (JsonReaderException)
                {
                    Console.WriteLine("Prutt! Det funkade inte.");
                }
            }
        }
    }
}
