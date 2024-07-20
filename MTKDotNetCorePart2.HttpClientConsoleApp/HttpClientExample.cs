using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MTKDotNetCorePart2.HttpClientConsoleApp
{
    internal class HttpClientExample
    {
        private readonly HttpClient _client = new HttpClient()
        {
            BaseAddress = new Uri("https://localhost:7013")
        };
        private readonly string _blogEndpoint = "api/blog";

        public async Task RunAsync()
        {
            //await ReadAsync();
            //await EditAsync(3);
            //await CreateAsync("11title", "11author", "11content");
            //await UpdateAsync(2, "updatetitle", "updateauthor", "updatecontent");
            //await DeleteAsync(3);
        }
        private async Task ReadAsync()
        {
            var response = await _client.GetAsync(_blogEndpoint);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                List<BlogDto> lst = JsonConvert.DeserializeObject<List<BlogDto>>(jsonStr)!;

                foreach (var blog in lst)
                {
                    Console.WriteLine(blog.BlogTitle);
                    Console.WriteLine(blog.BlogAuthor);
                    Console.WriteLine(blog.BlogContent);
                    Console.WriteLine("_____________________");
                }
            }
        }
        private async Task EditAsync(int id)
        {
            var response = await _client.GetAsync($"{_blogEndpoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                var item = JsonConvert.DeserializeObject<BlogDto>(jsonStr);

                Console.WriteLine(JsonConvert.SerializeObject(item));
                Console.WriteLine($"Title=>{item.BlogTitle}");
                Console.WriteLine($"Author=>{item.BlogAuthor}");
                Console.WriteLine($"Content=>{item.BlogContent}");
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }
        private async Task DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"{_blogEndpoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }
        private async Task CreateAsync(string title, string author, string content)
        {
            BlogDto blogDto = new BlogDto()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string blogJson = JsonConvert.SerializeObject(blogDto);
            HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8,Application.Json);
            var response = await _client.PostAsync(_blogEndpoint,httpContent);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }
        private async Task UpdateAsync(int id, string title,string author,string content)
        {
            BlogDto blogDto = new BlogDto()
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string blogJson = JsonConvert.SerializeObject(blogDto);
            HttpContent httpContent = new StringContent(blogJson,Encoding.UTF8,Application.Json);
            var response = await _client.PutAsync($"{_blogEndpoint}/{id}", httpContent);

            if(response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }
    }
       
}

