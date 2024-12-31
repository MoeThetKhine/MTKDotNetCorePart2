namespace MTKDotNetCorePart2.PizzaApi.Model;

[Table("Tbl_PizzaExtra")]
public class PizzaExtraModel
{
    [Key]
    [Column("PizzaExtraId")]
    public int Id { get; set; }

    [Column("PrizzaExtraName")]
    public string Name { get; set; }

    [Column("Price")]
    public decimal Price { get; set; }

    [NotMapped]
    public string PriceStr { get { return "$" + Price; } }
}
