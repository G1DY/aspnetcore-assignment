namespace Queue_Management_System.Models
{
    public class CheckInView
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime CheckInTime { get; set; }
        public string SelectedService { get; set; }
    }
}
