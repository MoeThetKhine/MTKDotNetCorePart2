namespace MTKDotNetCorePart2.PizzaApi.Features.Pizza;

[Route("api/[controller]")]
[ApiController]
public class PizzaController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public PizzaController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    #region GetAsync

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var lst = await _appDbContext.Pizzas.ToListAsync();
        return Ok(lst);
    }

    #endregion

    #region GetExtraAsync

    [HttpGet("Extras")]
    public async Task<IActionResult> GetExtraAsync()
    {
        var lst = await _appDbContext.PizzaExtras.ToListAsync();
        return Ok(lst);
    }

    #endregion

    #region GetOrder

    [HttpGet("Order/{invoiceNo}")]
    public async Task<IActionResult> GetOrder(string invoiceNo)
    {
        var item = await _appDbContext.PizzaOrders.FirstOrDefaultAsync(x => x.PizzaOrderInvoiceNo == invoiceNo);
        var lst = await _appDbContext.PizzaOrderDetails.Where(x=>x.PizzaOrderInvoiceNo ==invoiceNo).ToListAsync();
        return Ok(new
        {
            Order = item,   
            OrderDetail = lst
        });
    }

    #endregion

    #region OrderAsync

    [HttpPost("Order")]
    public async Task<IActionResult> OrderAsync(OrderResquestModel orderRequest)
    {
        var itemPizza = await _appDbContext.Pizzas.FirstOrDefaultAsync(x => x.Id == orderRequest.PizzaId);
        var total = itemPizza.Price;

        if(orderRequest.Extras.Length > 0)
        {
            var lstExtra = await _appDbContext.PizzaExtras.Where(x=> orderRequest.Extras.Contains(x.Id)).ToListAsync();
            total += lstExtra.Sum(x=> x.Price);
        }
        var invoiceNo = DateTime.Now.ToString("yyyyMMddHHmmss");
        PizzaOrderModel pizzaOrderModel = new PizzaOrderModel()
        {
            PizzaId = orderRequest.PizzaId,
            PizzaOrderInvoiceNo = invoiceNo ,
            TotalAmount = total
        };
        List<PizzaOrderDetailModel> pizzaExtraModels = orderRequest.Extras.Select(extraId => new PizzaOrderDetailModel
        {
            PizzaExtraId = extraId,
            PizzaOrderInvoiceNo = invoiceNo,
        }).ToList();

        await _appDbContext.PizzaOrders.AddAsync(pizzaOrderModel);
        await _appDbContext.PizzaOrderDetails.AddRangeAsync(pizzaExtraModels);
        await _appDbContext.SaveChangesAsync();

        OrderResponseModel responseModel = new OrderResponseModel()
        {
            InvoiceNo = invoiceNo,
            Message = "Thank You for your order! Enjoy your pizza",
            TotalAmount = total,
        };

        return Ok(responseModel);
    }

    #endregion



}
