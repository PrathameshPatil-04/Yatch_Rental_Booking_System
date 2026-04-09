using Microsoft.AspNetCore.Mvc;

namespace YatchRentalBooking.Controllers
{
    public class OwnerController : Controller
    {
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("UserEmail") == null)
                return RedirectToAction("Login", "Account");

            return View();
        }
    }
}
