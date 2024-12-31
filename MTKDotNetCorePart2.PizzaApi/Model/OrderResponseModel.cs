namespace MTKDotNetCorePart2.PizzaApi.Model;

public class OrderResponseModel
{
    public string Message { get; set; }
    public string InvoiceNo {  get; set; }
    public decimal TotalAmount { get; set; }
}
