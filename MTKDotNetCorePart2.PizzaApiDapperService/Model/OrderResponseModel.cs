﻿namespace MTKDotNetCorePart2.PizzaApiDapperService.Model;

#region OrderResquestModel

public class OrderResponseModel
{
    public string Message { get; set; }
    public string InvoiceNo { get; set; }
    public decimal TotalAmount { get; set; }
}

#endregion