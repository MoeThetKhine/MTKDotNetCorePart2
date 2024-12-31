namespace MTKDotNetCorePart2.NLayer.Features;

[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
    private readonly BL_Blog _bL_Blog;

    public BlogController(BL_Blog bL_Blog)
    {
        _bL_Blog = bL_Blog;
    }

    #region Read

    [HttpGet]
    public IActionResult Read()
    {
        var lst = _bL_Blog.GetBlogs();
        return Ok(lst);
    }

    #endregion

    #region Edit

    [HttpGet("{id}")]
    public IActionResult Edit(int id)
    {
        var item = _bL_Blog.GetBlog(id);
        if (item is null)
        {
            return NotFound("No data found");
        }

        return Ok(item);
    }

    #endregion

    #region Create

    [HttpPost]
    public IActionResult Create(BlogModel blog)
    {
        var result = _bL_Blog.CreateBlog(blog);
        string message = result > 0 ? "Saving Successful" : "Saving Failed";

        return Ok(message);
    }

    #endregion

    #region Update

    [HttpPut("{id}")]
    public IActionResult Update(int id, BlogModel blog)
    {
        var item = _bL_Blog.GetBlog(id);
        if (item is null)
        {
            return NotFound("No data found");
        }

        var result = _bL_Blog.UpdateBlog(id, blog);
        string message = result > 0 ? "Updating Successful" : "Updating Fail";

        return Ok(message);
    }

    #endregion

    #region Patch

    [HttpPatch("{id}")]
    public IActionResult Patch(int id, BlogModel blog)
    {
        var item = _bL_Blog.GetBlog(id);
        if (item is null)
        {
            return NotFound("No data found");
        }

        var result = _bL_Blog.PatchBlog(id, blog);
        string message = result > 0 ? "Updating Successful" : "Updating Fail";

        return Ok(message);
    }

    #endregion

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var item = _bL_Blog.GetBlog(id);
        if (item is null)
        {
            return NotFound("No data found");
        }

        var result = _bL_Blog.DeleteBlog(id);
        string message = result > 0 ? "Deleting Successful" : "Deleting Failed.";

        return Ok(message);
    }
}
