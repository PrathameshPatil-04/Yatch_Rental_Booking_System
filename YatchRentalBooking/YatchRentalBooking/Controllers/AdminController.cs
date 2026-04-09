using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YachtRentalMVC.Data;

namespace YatchRentalBooking.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("UserEmail") == null)
                return RedirectToAction("Login", "Account");

            return View();
        }
    }
}
