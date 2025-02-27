﻿using Queue_Management_System.Models;
using System;
using System.Collections.Generic;

namespace Queue_Management_System.Controllers
{
    public interface IServicesModel
    {
        CheckInModel Dequeue();
        IEnumerable<CheckInModel> GetQueue();
    }

    public class ServicePointController
    {
        private readonly IServicesModel serviceModel;

        public ServicePointController(IServicesModel serviceModel)
        {
            this.serviceModel = serviceModel ?? throw new ArgumentNullException(nameof(serviceModel));
        }

        public CheckInModel ProcessNextTicket()
        {
            var nextTicket = serviceModel.Dequeue();

            // Logic to handle the next ticket
            if (nextTicket != null)
            {
                Console.WriteLine($"Processing ticket {nextTicket.TicketNumber} for service {nextTicket.TicketNumber}");
            }
            else
            {
                Console.WriteLine("No tickets available for processing");
            }

            return nextTicket;
        }

        public void MarkTicketAsNoShow(CheckInModel ticket)
        {
            // Logic to mark a ticket as a no-show
            Console.WriteLine($"Marking ticket {ticket.TicketNumber} as a no-show");
            // To include more logic
        }

        public void MarkTicketAsFinished(CheckInModel ticket)
        {
            // Logic to mark a ticket as finished
            Console.WriteLine($"Marking ticket {ticket.TicketNumber} as finished");
            // To include more logic
        }

        public void TransferTicket(CheckInModel ticket, ServicePointController targetServicePoint)
        {
            // Logic to transfer a ticket to another service point
            Console.WriteLine($"Transferring ticket {ticket.TicketNumber} to {targetServicePoint}");
            targetServicePoint.ProcessNextTicket();
            // To include more logic
        }

        public void ViewQueue()
        {
            // Logic to view the current queue
            var queue = serviceModel.GetQueue();
            Console.WriteLine("Current Queue:");
            foreach (var queuedTicket in queue)
            {
                Console.WriteLine($"Ticket {queuedTicket.TicketNumber} - Service {queuedTicket.TicketNumber}");
            }
        }
    }
}
