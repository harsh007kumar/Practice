using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace Await_Basics
{
    class MainClass
    {
        public static void Main()
        {
            //string[] args = Environment.GetCommandLineArgs();
            string input = "http://docs.microsoft.com";
            if (input.Length > 1)
                GetPageSizeAsync(input).Wait();
            else
                Console.WriteLine("Enter atleast one Url");
            
            Console.WriteLine("Hello World!");
        }

        private static async Task GetPageSizeAsync(string url)
        {
            byte[] urlContents = await (new HttpClient().GetByteArrayAsync(url));
            Console.WriteLine($"{url}: {urlContents.Length / 2:N0} characters");
        }

    }
}
