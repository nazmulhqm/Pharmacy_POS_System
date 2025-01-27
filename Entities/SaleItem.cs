using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Pharmacy_POS_System.Entities
{
    public class SaleItem
    {
        [Key]
        public int SaleItemId { get; set; }
        public int SaleId { get; set; }
        [JsonIgnore]
        public Sale? Sale { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set;}
        public decimal SubTotal { get; set; }
    }
}
