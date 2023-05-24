using System;
namespace api_bharat_lawns.Model
{
    public class PaymentReceipt : Root
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public int InvoiceId { get; set; }

        public PaymentMode PaymentMode { get; set; }

        public PaymentType PaymentType { get; set; }

    }


    public enum PaymentMode
    {
        Cash = 1,
        Online
    }

    public enum PaymentType
    {
        Advance = 1,
        Partial,
        Full
    }
}

