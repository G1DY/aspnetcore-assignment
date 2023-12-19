using System.Net.Sockets;
using System.Net;

namespace Queue_Management_System.Models
{
    public class ServicePointAssignment
    {
        public int AssignmentId { get; set; }
        public int ServiceId { get; set; }
        public int ServicePointId { get; set; }
        public int TicketId { get; set; }

        // Navigation properties
        // public virtual Service Service { get; set; }
        public virtual ServicePoint ServicePoint { get; set; }
        //public virtual Ticket Ticket { get; set; }
    }
}

