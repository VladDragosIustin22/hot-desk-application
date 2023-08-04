namespace HotDeskApplicationApi.ModelView
{
    public class ReservationInput
    {
        public DateTime ArrivalTime { get; set; }
        public DateTime LeavingTime { get; set; }
        public Guid OfficeID { get; set; }
        public Guid FloorID { get; set; }
        public Guid DeskID { get; set; }
    }
}
