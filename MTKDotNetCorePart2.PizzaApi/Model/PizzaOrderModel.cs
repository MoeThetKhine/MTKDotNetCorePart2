﻿namespace MTKDotNetCorePart2.PizzaApi.Model;

#region PizzaOrderModel

[Table("Tbl_PizzaOrder")]
public class PizzaOrderModel
{
    [Key]
    public int PizzaOrderId {  get; set; }
    public string PizzaOrderInvoiceNo {  get; set; }
    public int PizzaId {  get; set; }
    public decimal TotalAmount {  get; set; }   
}

#endregion
