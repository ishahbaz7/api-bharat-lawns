using System;
using System.Text.Json.Serialization;
using api_bharat_lawns.CustomeValidation;

namespace api_bharat_lawns.Model
{
    public class Invoice : Root
    {
        public int Id { get; set; }

        public int? InvoiceNo { get; set; }

        [RequiredNum]
        public decimal TotalAmount { get; set; }

        public decimal Tax { get; set; }

        public decimal Discount { get; set; }

        public decimal Advance { get; set; }

        public decimal Balance { get; set; }

        public InvoiceStatus Status { get; set; }

        public Booking? Booking { get; set; }

        public List<PaymentReceipt>? PaymentReciept { get; set; }
    }

    public enum InvoiceStatus
    {
        Paid = 1,
        UnPaid,
        Partial
    }
}

