using MTKDotNetCorePart2.NLayer.Features;
using MTKDotNetCorePart2.NLayer.Model;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTKDotNetCorePart2.ConsoleAppRefitExample
{
    public class RefitExample
    {
        private readonly IBlogApi _service = RestService.For<IBlogApi>("https://localhost:7188");

        #region RunAsync

        public async Task RunAsync()
        {
            //await ReadAsync();
            //await EditAsync(1);
            //await EditAsync(100);
            //await CreateAsync("stringtitle", "stringauthor", "stringcontent");
            //await UpdateAsync(2, "stringtitleedit", "stringauthoredit", "stringcontentedit");
            //await UpdateAsync(90, "stringtitleedit", "stringauthoredit", "stringcontentedit");
            await DeleteAsync(25);
        }

        #endregion

        #region ReadAync

        private async Task ReadAsync()
        {
            var lst = await _service.GetBlogs();

            foreach (var item in lst)
            {
                Console.WriteLine($"Id=>{item.BlogId}");
                Console.WriteLine($"Title => {item.BlogTitle}");
                Console.WriteLine($"Author =>{item.BlogAuthor}");
                Console.WriteLine($"Content =>{item.BlogContent}");
                Console.WriteLine("_____________________________________");
            }
        }

        #endregion

        #region EditAsync

        private async Task EditAsync(int id)
        {
            try
            {
                var item = await _service.GetBlog(id);
                Console.WriteLine($"Id=>{item.BlogId}");
                Console.WriteLine($"Title => {item.BlogTitle}");
                Console.WriteLine($"Author =>{item.BlogAuthor}");
                Console.WriteLine($"Content =>{item.BlogContent}");
                Console.WriteLine("_____________________________________");
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.StatusCode.ToString());
                Console.WriteLine(ex.Content);
            }
        }

        #endregion

        #region CreateAsync

        private async Task CreateAsync(string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };

            var message = await _service.CreateBlog(blog);
            Console.WriteLine(message);
        }

        #endregion

        #region UpdateAsync

        private async Task UpdateAsync(int id, string tilte, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogId = id,
                BlogTitle = tilte,
                BlogAuthor = author,
                BlogContent = content,
            };
            var message = await _service.UpdateBlog(id, blog);
            Console.WriteLine(message);
        }

        #endregion

        #region DeleteAsync

        private async Task DeleteAsync(int id)
        {

            var item = _service.GetBlog(id);
            if (item is null)
            {
                Console.WriteLine("No data found");
            }
            var message = await _service.DeleteBlog(id);
            Console.WriteLine(message);
        }

        #endregion

    }
}
