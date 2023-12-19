using Microsoft.AspNetCore.Mvc;
using Queue_Management_System.Models;

namespace Queue_Management_System.Controllers
{
    public class CheckInViewController : Controller
    {
        private ServicesModel serviceModel;

        public CheckInViewController(ServicesModel serviceModel)
        {
            this.serviceModel = serviceModel;
        }

        public TicketsModel CheckIn(string serviceName)
        {
            var ticketNumber = GenerateTicketNumber();
            var ticket = new TicketsModel { ServiceName = serviceName, TicketNumber = ticketNumber };
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
            // You might want to use a service or repository for database operations.
            // Example using a service method named CreateData
            // var result = dataBaseHelper.CreateData($"User: {model.UserName}, Check-in Time: {DateTime.Now}");

            // Redirect to the check-in confirmation page
            return RedirectToAction("CheckInConfirmation");
        }

        public IActionResult CheckInConfirmation()
        {
            return View();
        }
    }
}