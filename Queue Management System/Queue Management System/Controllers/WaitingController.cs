using Queue_Management_System.Models;
using System;
using System.Collections.Generic;

namespace Queue_Management_System.Controllers
{
    public class WaitingController
    {
        private ServicesModel services;

        public WaitingController(ServicesModel services)
        {
            this.services = services;
        }

        public TicketsModel NextTicket
        {
            get
            {
                return services.Dequeue();
            }
        }
    }
}
