namespace MTKDotNetCorePart2.PizzaApiDapperService.Model;

public class PizzaOrderInvoiceHeadModel
{
    public int PizzaOrderId { get; set; }
    public string PizzaOrderInvoiceNo { get; set; }
    public int PizzaId { get; set; }
    public decimal TotalAmount { get; set; }
    public string Pizza { get; set; }
    public string Price { get; set; }


}
