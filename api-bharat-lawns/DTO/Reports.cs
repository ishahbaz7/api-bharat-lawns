namespace api_bharat_lawns.DTO
{
    public class Reports
    {
        public decimal Collection { get; set; }
        public decimal BookingsValue { get; set; }
        public decimal PendingAmount { get; set; }
        public int Bookings { get; set; }
        public int Morning { get; set; }
        public int Evening { get; set; }
        public int FullDay { get; set; }
        public DateTime Date { get; set; }
    }
}