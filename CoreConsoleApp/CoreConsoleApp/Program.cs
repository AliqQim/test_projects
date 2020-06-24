using System;
using System.Threading.Tasks;

namespace CoreConsoleApp
{
    class Program
    {
        async static Task Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);
            await f(async () =>
            {
                await Task.Delay(1000);
                return DateTime.Now;
            });

            Console.WriteLine("DONE");
        }

        
        async static Task f(Func<Task<DateTime>> a)
        {
            Console.WriteLine(await a());
        }
    }
}
