namespace MTKDotNetCorePart2.PizzaApiDapperService.Model
{
        [Table("Tbl_Pizza")]
        public class PizzaModel
        {
            [Key]
            [Column("PizzaId")]
            public int PizzaId { get; set; }

            [Column("Pizza")]
            public string Pizza {  get; set; }

            [Column("Price")]
            public decimal Price {  get; set; }
         }
}
