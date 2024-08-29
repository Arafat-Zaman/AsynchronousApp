using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to the Async Console App!");

            // Fetching data from a fake API asynchronously
            string posts = await FetchPostsAsync();

            Console.WriteLine("Fetched Posts:");
            Console.WriteLine(posts);
        }

        static async Task<string> FetchPostsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                // Making an asynchronous GET request to fetch posts
                HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");

                // Ensure the response is successful
                response.EnsureSuccessStatusCode();

                // Read the response content asynchronously
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
