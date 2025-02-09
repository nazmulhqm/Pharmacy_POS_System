using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Pharmacy_POS_System.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        [JsonIgnore]
        public Category? Category { get; set; }
        public int? BrandId { get; set; }
        [JsonIgnore]
        public Brand? Brand { get; set; }
        public string? ProductImage { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }

        public int Stock { get; set; } = 0;
        public double Price { get; set; } = 0.00;
        public double DefaultDiscount { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

}
