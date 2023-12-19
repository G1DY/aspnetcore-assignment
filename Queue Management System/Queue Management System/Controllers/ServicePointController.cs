using Queue_Management_System.Models;
using System;
namespace Queue_Management_System.Controllers
{
    public class ServicePointController
    {
        private ServicesModel servicesModel;

        public ServicePointController(ServicesModel servicesModel)
        {
            this.servicesModel = servicesModel;
        }

        public TicketsModel ProcessNextTicket()
        {
            var nextTicket = servicesModel.Dequeue();

            // Logic to handle the next ticket
            if (nextTicket != null)
            {
                Console.WriteLine($"Processing ticket {nextTicket.Number} for service {nextTicket.Service}");
                // To include more logic
            else
            {
                Console.WriteLine("No tickets available for processing");
            }

            return nextTicket;
        }

        public void MarkAsNoShow(TicketsModel ticket)
        {
            // Logic to mark a ticket as a no-show
            Console.WriteLine($"Marking ticket {ticket.Number} as a no-show");
            // To include more Logic
        }

        public void MarkAsFinished(TicketsModel ticket)
        {
            // Logic to mark a ticket as finished
            Console.WriteLine($"Marking ticket {ticket.Number} as finished");
            // To include more Logic
        }

        public void TransferTicket(TicketsModel ticket, ServicePointController targetServicePoint)
        {
            // Logic to transfer a ticket to another service point
            Console.WriteLine($"Transferring ticket {ticket.Number} to {targetServicePoint}");
            targetServicePoint.ProcessNextTicket();
            // To include more Logic
        }

        public void ViewQueue()
        {
            // Logic to view the current queue
            var queue = servicesModel.EnQueue();
            Console.WriteLine("Current Queue:");
            foreach (var queuedTicket in queue)
            {
                Console.WriteLine(value: $"Ticket {queuedTicket.Number} - Service {queuedTicket.Service}");
            }
        }
    }
}
