namespace MTKDotNetCorePart2.MyanmarProverbsApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MyanmarProverbsController : ControllerBase
{
    #region GetDataFromApi

    private async Task<Tbl_Mmproverbs> GetDataFromApi()
    {
        //HttpClient client = new HttpClient();
        //var response = await client.GetAsync("https://raw.githubusercontent.com/sannlynnhtun-coding/Myanmar-Proverbs/main/MyanmarProverbs.json");
        //if (response.IsSuccessStatusCode)
        //{
        //    string jsonStr = await response.Content.ReadAsStringAsync();
        //    var model =  JsonConvert.DeserializeObject<Tbl_Mmproverbs>(jsonStr);
        //    return model;
        //}
        //return null;

        var jsonStr = await System.IO.File.ReadAllTextAsync("data.json");
        var model = JsonConvert.DeserializeObject<Tbl_Mmproverbs>(jsonStr);
        return model;
    }

    #endregion

    #region Get

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var model = await GetDataFromApi();
        return Ok(model.Tbl_MMProverbsTitle);
    }

    #endregion

    #region Get

    [HttpGet("{titleName}")]
    public async Task<IActionResult> Get(string titleName)
    {
        var model = await GetDataFromApi();
        var item = model.Tbl_MMProverbsTitle.FirstOrDefault(x => x.TitleName == titleName);
        if (item == null)
        {
            return NotFound();
        }
        var titleId = item.TitleId;
        var result = model.Tbl_MMProverbs.Where(x => x.TitleId == titleId);

        List<Tbl_MmproverbsHead> lst = result.Select(x => new Tbl_MmproverbsHead
        {
            ProverbId = x.ProverbId,
            ProverbName = x.ProverbName,
            TitleId = x.TitleId,
        }).ToList();

        return Ok(lst);
    }

    #endregion

    #region Get

    [HttpGet("{titleId}/{proverbId}")]
    public async Task<IActionResult> Get(int titleId,int proverbId)
    {
        var model = await GetDataFromApi();
        var item = model.Tbl_MMProverbs.FirstOrDefault(x => x.TitleId ==titleId && x.ProverbId == proverbId);

        return Ok(item);
    }

    #endregion

}

#region Tbl_Mmproverbs

public class Tbl_Mmproverbs
{
    public Tbl_Mmproverbstitle[] Tbl_MMProverbsTitle { get; set; }
    public Tbl_MmproverbsDetails[] Tbl_MMProverbs { get; set; }
}

#endregion

#region Tbl_Mmproverbstitle

public class Tbl_Mmproverbstitle
{
    public int TitleId { get; set; }
    public string TitleName { get; set; }
}

#endregion

public class Tbl_MmproverbsDetails
{
    public int TitleId { get; set; }
    public int ProverbId { get; set; }
    public string ProverbName { get; set; }
    public string ProverbDesp { get; set; }
}
public class Tbl_MmproverbsHead
{
    public int TitleId { get; set; }
    public int ProverbId { get; set; }
    public string ProverbName { get; set; }
  
}
