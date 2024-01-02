using Microsoft.AspNetCore.Mvc;
using Queue_Management_System.Data;
using Queue_Management_System.Models;
using System.Diagnostics.Tracing;

namespace Queue_Management_System.Controllers
{
    public class CheckInController : Controller
    {
        private readonly DataBaseHelper _dataBaseHelper;
        public CheckInController()
        {
            _dataBaseHelper = new DataBaseHelper("DefaultConnectionString");
        }
        [HttpPost("/CheckIn")]
        public IActionResult CheckIn([FromBody] CheckInModel checkinRequest)
        {
            // logic to generate ticket

            string ticketNumber = $"T{DateTime.Now:yyyyMMddHHmmss}";
            string? serviceName = checkinRequest.SelectedService;

            // inserting ticket to DB
            _dataBaseHelper.CreateCheckInData($"{checkinRequest.TicketNumber},{checkinRequest.Time},{checkinRequest.SelectedService}");

            // response
            return Ok(new { TicketNumber = ticketNumber, ServiceName = serviceName });
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string ticketNumber)
        {
            var TicketNumber = new Random().Next(1000, 9999);
            var CheckIn = new CheckInModel
            {
                TicketNumber = TicketNumber,
                SelectedService = "",
                Time = DateTime.Now

            };

            _dataBaseHelper.CreateCheckInData($"{CheckIn.TicketNumber},{CheckIn.Time},{CheckIn.SelectedService}");

            ViewBag.TicketNumber = TicketNumber;

            return View("Ticket");
        }
        
    }
}
