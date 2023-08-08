namespace HotDeskApplicationApi.ModelView
{
    public class AdminReservation
    {
       public Guid UserID { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime LeavingTime { get; set; }
        public Guid OfficeID { get; set; }
        public Guid FloorID { get; set; }
        public Guid DeskID { get; set; }
    }
}
