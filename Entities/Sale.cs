namespace Pharmacy_POS_System.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<SaleItem>? SaleItems { get; set; } = new List<SaleItem>();
        public Payment? Payment { get; set; }
    }
}
