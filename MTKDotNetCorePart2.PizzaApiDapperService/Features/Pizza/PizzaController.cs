namespace MTKDotNetCorePart2.PizzaApiDapperService.Features.Pizza
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly DapperService _dapperService;

        public PizzaController()
        {
            _dapperService = new DapperService(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);

        }

        [HttpGet("Order/{invoiceNo}")]
        public IActionResult GetOrder(string invoiceNo)
        {
            var item = _dapperService.QueryFirstOrDefault<PizzaOrderInvoiceHeadModel>
                (
                    PizzaQuery.PizzaOrderQuery,
                    new { PizzaOrderInvoiceNo = invoiceNo }
                );

            var lst = _dapperService.Query<PizzaOrderInvoiceDetailModel>
                (
                    PizzaQuery.PizzaOrderDetailQuery,
                    new { PizzaOrderInvoiceNo = invoiceNo }
                );
            var model = new PizzaOrderInvoiceResponseModel
            {
             Order = item,
             OrderDetail = lst
            };
            return Ok(model);
        }

        [HttpGet]
        public IActionResult GetPizza()
        {
            string query = "select * from Tbl_Pizza";
            var lst = _dapperService.Query<PizzaModel>(query);

            return Ok(lst);
        }

        [HttpGet("Extra")]
        public IActionResult GetExtras()
        {
            string query = "select * from Tbl_PizzaExtra";
            var lst = _dapperService.Query<PizzaExtraModel>(query);

            return Ok(lst);
        }
    }
}
