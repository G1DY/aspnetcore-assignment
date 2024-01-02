using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Queue_Management_System.Models
{
    public class ServicePoints
    {
        [Key]
        public int ServicePointId { get; set; }
        public string? ServiceName { get; set; }

        // relationship
        public List<CheckInModel> CheckIns { get; set; }
    }
}
