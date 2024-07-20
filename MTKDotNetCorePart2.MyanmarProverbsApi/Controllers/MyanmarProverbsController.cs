using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MTKDotNetCorePart2.MyanmarProverbsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyanmarProverbsController : ControllerBase
    {
        private async Task<Tbl_Mmproverbs> GetDataFromApi()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://raw.githubusercontent.com/sannlynnhtun-coding/Myanmar-Proverbs/main/MyanmarProverbs.json");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                var model =  JsonConvert.DeserializeObject<Tbl_Mmproverbs>(jsonStr);
                return model;
            }
            return null;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var model = await GetDataFromApi();
            return Ok(model.Tbl_MMProverbsTitle);
        }
        [HttpGet("{titleName}")]
        public async Task<IActionResult>Get(string titleName)
        {
            var model = await GetDataFromApi();
            var item = model.Tbl_MMProverbsTitle.FirstOrDefault(x=>x.TitleName == titleName);
            if (item == null)
            {
                return NotFound();
            }
            var titleId = item.TitleId;
            var lst = model.Tbl_MMProverbs.Where(x => x.TitleId == titleId);
            return Ok(lst);
        }
    }

    public class Tbl_Mmproverbs
    {
        public Tbl_Mmproverbstitle[] Tbl_MMProverbsTitle { get; set; }
        public Tbl_MmproverbsDetails[] Tbl_MMProverbs { get; set; }
    }

    public class Tbl_Mmproverbstitle
    {
        public int TitleId { get; set; }
        public string TitleName { get; set; }
    }

    public class Tbl_MmproverbsDetails
    {
        public int TitleId { get; set; }
        public int ProverbId { get; set; }
        public string ProverbName { get; set; }
        public string ProverbDesp { get; set; }
    }

}
