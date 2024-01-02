using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Queue_Management_System.Models
{
    public class CheckInModel
    {
        [Key]
        public int TicketNumber { get; set; }
        public DateTime Time { get; set; }
        public String? SelectedService { get; set; }

        [ForeignKey("ServicePointId")]
        public int ServicePointId  { get; set; }
        public virtual ServicePoints? ServicePoints { get; set; }


    }
}
