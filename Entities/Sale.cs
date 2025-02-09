using Microsoft.AspNetCore.Http.HttpResults;
using Pharmacy_POS_System.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Pharmacy_POS_System.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public decimal Total { get; set; }
        public decimal? Discount { get; set; } = 0;
        public decimal? Vat { get; set; } = 0;
        public decimal? Adjustment { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<SaleItem>? SaleItems { get; set; } = new List<SaleItem>();
        public Payment? Payment { get; set; }
    }
}
