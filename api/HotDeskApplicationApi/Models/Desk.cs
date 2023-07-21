namespace HotDeskApplicationApi.Models
{
    public class Desk
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public Guid FloorID { get; set; }
    }
}
