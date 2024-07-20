using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTKDotNetCorePart2.RestClientConsoleApp
{
    internal class RestClientExample
    {
        private readonly RestClient _client = new RestClient(new Uri("https://localhost:7186"));

        private readonly string _blogEndpoint = "api/blog";

        public async Task RunAsync()
        {
            await ReadAsync();
            //await EditAsync(2);
            //await CreateAsync("sstitle", "ssauthor", "sscontent");
           // await UpdateAsync(3, "aatitle", "aaauthor", "aacontent");
           // await DeleteAsync(5);
        }
        private async Task ReadAsync()
        {
            //RestResquest restRequest = new RestRequest(_blogEndpoint);
            //var response = await _client.GetAsync(restRequest);

            RestRequest restRequest = new RestRequest(_blogEndpoint, Method.Get);
            var response = await _client.ExecuteAsync(restRequest);

            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                List<BlogDto>lst = JsonConvert.DeserializeObject<List<BlogDto>>(jsonStr)!;

                foreach(var item in lst)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(item));
                    Console.WriteLine($"Title=>{item.BlogTitle}");
                    Console.WriteLine($"Author=>{item.BlogAuthor}");
                    Console.WriteLine($"Content=>{item.BlogContent}");
                }
            }
        }
        private async Task EditAsync(int id)
        {
            RestRequest restRequest = new RestRequest($"{_blogEndpoint}/{id}",Method.Get);
            var response = await _client.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                var item = JsonConvert.DeserializeObject<BlogDto>(jsonStr)!;
                Console.WriteLine(JsonConvert.SerializeObject(item));
                Console.WriteLine($"Title=>{item.BlogTitle}");
                Console.WriteLine($"Author=>{item.BlogAuthor}");
                Console.WriteLine($"Content=>{item.BlogContent}");
            }
            else
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }

        private async Task CreateAsync(string title,string author, string content)
        {
            BlogDto blogDto = new BlogDto()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            var restResquest = new RestRequest(_blogEndpoint, Method.Post);
            restResquest.AddJsonBody(blogDto);
            var response = await _client.ExecuteAsync(restResquest);
            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }

        private async Task UpdateAsync(int id,string title, string author, string content)
        {
            BlogDto blogDto = new BlogDto()
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            var restResquest = new RestRequest($"{_blogEndpoint}/{id}", Method.Put);
            restResquest.AddJsonBody(blogDto);
            var response = await _client.ExecuteAsync(restResquest);
            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }

        private async Task DeleteAsync(int id)
        {
            RestRequest restRequest= new RestRequest($"{_blogEndpoint}/{id}", Method.Delete);
            var response = await _client.ExecuteAsync(restRequest);

            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine(message); 
            }
            else
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }
    }
}
