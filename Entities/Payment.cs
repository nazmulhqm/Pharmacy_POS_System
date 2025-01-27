using System.Text.Json.Serialization;

namespace Pharmacy_POS_System.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public int SaleId { get; set; }
        [JsonIgnore]
        public Sale? Sale { get; set; }

        public decimal Amount { get; set; }
        public string Method { get; set; }
        public DateTime Date { get; set; }


    }
}
