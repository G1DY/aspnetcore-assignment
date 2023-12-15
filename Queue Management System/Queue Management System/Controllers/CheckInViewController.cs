using Microsoft.AspNetCore.Mvc;
using Queue_Management_System.Data;
using Queue_Management_System.Models;
using System;

namespace Queue_Management_System.Controllers
{
    public class CheckInViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckInView(CheckInView model)
        {
            // Handle the check-in logic (e.g., store the data in the database)
            // and a method like CreateData to handle database operations.

            var dataBaseHelper = new DataBaseHelper("your_connection_string");
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