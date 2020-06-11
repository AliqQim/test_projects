using System;
using System.Net.Http;
using System.Threading.Tasks;
using test_proxies;

namespace NSwagClient
{
    class Program
    {
        async static Task Main(string[] args)
        {
            using var httpClient = new HttpClient();

            var client = new swaggerClient("https://localhost:44354/", httpClient);

            Console.WriteLine("обращаемся к сервису...");
            Console.WriteLine(await client.WeatherForecastAsync(1, 2));
            Console.WriteLine(await client.IsAvailableForChattingUpAsync(
                new Person
                {
                    Age = 88,
                    IsFemale = false,
                    Name = "Сидор"
                }));


            Console.WriteLine("Hello World!");
        }
    }
}
