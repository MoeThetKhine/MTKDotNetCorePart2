namespace MTKDotNetCorePart2.PizzaApiDapperService.Model;

#region PizzaOrderInvoiceResponseModel

public class PizzaOrderInvoiceResponseModel
{
    public PizzaOrderInvoiceHeadModel Order {  get; set; }

    public List<PizzaOrderInvoiceDetailModel> OrderDetail { get; set; }
}

#endregion