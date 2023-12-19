namespace Queue_Management_System.Models
{
    public class TicketsModel
    {
        public int TicketId { get; set; }
        public string? TicketNumber { get; set; }

        private string _status = "waiting";
        public string Status 
        { 
            get { return _status; }

            set { _status = value; }
        }

        public string ServiceName { get; internal set; }
    }
}
