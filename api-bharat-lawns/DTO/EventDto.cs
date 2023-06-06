using api_bharat_lawns.Model;

namespace api_bharat_lawns.DTO
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Status Status { get; set; }
    }
}