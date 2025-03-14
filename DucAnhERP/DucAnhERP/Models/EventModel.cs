namespace DucAnhERP.Models
{
    public class EventModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString(); // Định danh duy nhất
        public string Title { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Color { get; set; }
    }

}
