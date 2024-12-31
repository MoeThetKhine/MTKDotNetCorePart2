﻿namespace MTKDotNetCorePart2.PizzaApiDapperService.Model;

#region PizzaOrderDetailModel

[Table("Tbl_PizzaOrderDetail")]
public class PizzaOrderDetailModel
{
    [Key]
    public int PizzaOrderDetailId {  get; set; }
    public string PizzaOrderInvoiceNo { get; set; }
    public int PizzaExtraId { get; set; }
}

#endregion