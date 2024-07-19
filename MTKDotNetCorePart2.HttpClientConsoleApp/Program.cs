using Newtonsoft.Json;

Console.WriteLine("Hello, World!");

// ConsoleApp - Client(Frontend)
// Asp.Net Core Web Api - Server(Backend)

HttpClient client = new HttpClient();
var response = await client.GetAsync("https://localhost:7013/api/blog");

if (response.IsSuccessStatusCode)
{
    string jsonStr = await response.Content.ReadAsStringAsync();
    Console.WriteLine(jsonStr);
    List<BlogDto> lst = JsonConvert.DeserializeObject<List<BlogDto>>(jsonStr)!;
    foreach (var blog in lst)
    {
        Console.WriteLine(JsonConvert.SerializeObject(blog));
    }
}

public class BlogDto
{
    public long BlogId { get; set; }
    public string BlogTitle { get; set; }
    public string BlogAuthor { get; set; }
    public string BlogContent { get; set; }
    public bool IsActive { get; set; }
}
