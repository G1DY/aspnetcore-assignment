using Microsoft.AspNetCore.Mvc;
using Queue_Management_System.Data;
using Queue_Management_System.Models;
using System;

namespace Queue_Management_System.Controllers
{
    public class CheckInViewController : Controller
    {
        private ServiceModel serviceModel;

        public CheckInController(ServiceModel serviceModel)
        {
            this.serviceModel = serviceModel;
        }

        public TicketModel CheckIn(string serviceName)
        {
            var ticketNumber = GenerateTicketNumber();
            var ticket = new TicketModel { Service = serviceName, Number = ticketNumber };
            serviceModel.Enqueue(ticket);
            return ticket;
        }

        private string GenerateTicketNumber()
        {
            // Implement logic to generate a unique ticket number
            // For simplicity, using a static counter here
            return "A" + (serviceModel.GetQueueLength() + 1);
        }
        public IActionResult Index()
        { 

            ViewData["Message"] = "Hello, World!";
            return View();
        }

        [HttpPost]
        public IActionResult CheckInView(CheckInView model)
        {
            // Handle the check-in logic (e.g., store the data in the database)
            // and a method like CreateData to handle database operations.

            var dataBaseHelper = new DataBaseHelper("Host=localhost;Port=5432;Database=QueueManagementSystem;Username=postgres;Password=K1pker1ng;");
            dataBaseHelper.CreateData($"User: {model.UserName}, Check-in Time: {DateTime.Now}");

            // Redirect to the check-in confirmation page
            return RedirectToAction("CheckInConfirmation");
        }

        public IActionResult CheckInConfirmation()
        {
            return View();
        }
    }
}