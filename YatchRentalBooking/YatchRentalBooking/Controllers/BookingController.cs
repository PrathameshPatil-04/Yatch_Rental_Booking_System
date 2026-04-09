using Microsoft.AspNetCore.Mvc;
using YachtRentalMVC.Data;

public class BookingController : Controller
{
    private readonly AppDbContext _context;

    public BookingController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Dashboard()
    {
        if (HttpContext.Session.GetString("UserEmail") == null)
            return RedirectToAction("Login", "Account");

        return View();
    }

    // 👉 Show booking page
    public IActionResult Create(int boatId)
    {
        var boat = _context.Boats.Find(boatId);

        if (boat == null)
            return NotFound();

        return View(boat);
    }

    // 👉 After form submit → go to payment
    [HttpPost]
    public IActionResult Create(int boatId, int hours)
    {
        var boat = _context.Boats.Find(boatId);

        if (boat == null)
            return NotFound();

        decimal total = boat.PricePerHour * hours;

        // 👉 pass to payment
        return RedirectToAction("Pay", "Payment",
            new { amount = total, boatId = boatId, hours = hours });
    }
}