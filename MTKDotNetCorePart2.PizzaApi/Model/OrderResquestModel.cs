namespace MTKDotNetCorePart2.PizzaApi.Model;

#region OrderResquestModel

public class OrderResquestModel
{
    public int PizzaId {  get; set; }
    public int[] Extras { get; set; }
}

#endregion