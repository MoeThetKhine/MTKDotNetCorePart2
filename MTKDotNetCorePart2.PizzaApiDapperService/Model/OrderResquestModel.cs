﻿namespace MTKDotNetCorePart2.PizzaApiDapperService.Model;

#region OrderResquestModel

public class OrderResquestModel
{
    public int PizzaId { get; set; }
    public int[] Extras { get; set; }
}

#endregion