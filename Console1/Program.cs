using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Console1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new swaggerClient("https://localhost:5001",new HttpClient());
            var a = await client.CourseAllAsync();
            
            foreach(var item in a)
            {
                Console.WriteLine(item.Title);
            }
           
        }
    }
}
