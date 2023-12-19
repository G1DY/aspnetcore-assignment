using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Queue_Management_System.Models;

namespace Queue_Management_System.Controllers
{
    [Authorize]
    public class AdminDashboardController : Controller
    {
        private readonly ServicesModel _services;

        public AdminDashboardController(ServicesModel services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Return the main admin dashboard view
            return View();
        }

        [HttpPost]
        public IActionResult ConfigureService(string serviceName)
        {
            // Logic to configure a service
            //object value = _services.ConfigureService(serviceName);

            // Redirect to a different action or return a view
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult ConfigureProvider(string providerName)
        {
            // Logic to configure a service provider
            _services.ConfigureProvider(providerName);

            // Redirect to a different action or return a view
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult GenerateReport()
        {
            // Logic to generate an analytical report

            // Return a view or some result
            return View();
        }
    }
}
