using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using YatchRentalBooking.Models;

namespace YatchRentalBooking.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
