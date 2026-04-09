using Microsoft.AspNetCore.Mvc;
using YachtRentalMVC.Data;
using YachtRentalBooking.Models;


public class AccountController : Controller
{
    private readonly AppDbContext _context;

    public AccountController(AppDbContext context)
    {
        _context = context;
    }


    public IActionResult Register() => View();

    [HttpPost]
    public IActionResult Register(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();

        return RedirectToAction("Login");
    }

    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(User login)
    {
        var user = _context.Users.FirstOrDefault(x =>
            x.Email.ToLower() == login.Email.ToLower() &&
            x.Password == login.Password &&
            x.Role == login.Role);

        if (user == null)
        {
            ViewBag.Message = "Invalid Credentials ❌";
            return View();
        }

        // ✅ STORE SESSION
        HttpContext.Session.SetString("UserEmail", user.Email);
        HttpContext.Session.SetString("UserRole", user.Role);
        HttpContext.Session.SetString("UserName", user.Name);

        // ✅ ROLE BASED REDIRECT
        if (user.Role == "Admin")
            return RedirectToAction("Dashboard", "Admin");

        if (user.Role == "Owner")
            return RedirectToAction("Dashboard", "Owner");

        return RedirectToAction("Index", "Boat");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }
}