namespace HotDeskApplicationApi.Models
{
    public class Reservation
    {
        public Guid ID { get; set; }
        public Guid ProfileID { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime LeavingTime { get; set; }
        public Guid OfficeID { get; set; }
        public Guid FloorID { get; set; }
        public Guid DeskID { get; set; }
    }
}
