using api_bharat_lawns.CustomeValidation;

namespace api_bharat_lawns.Model
{
    public class BookedProgram : Root
    {
        public int Id { get; set; }
        [RequiredNum]
        public int BookingId { get; set; }
        public Booking? Booking { get; set; }
        [RequiredNum]
        public int ProgramId { get; set; }
        public ProgramType? ProgramType { get; set; }
        [RequiredNum]
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        [RequiredNum]
        public decimal Amount { get; set; }
    }

}