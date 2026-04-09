using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Razorpay.Api;
using YachtRentalMVC.Data;
using YatchRentalBooking.Models;

public class PaymentController : Controller
{
    private readonly AppDbContext _context;

    public PaymentController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Pay(decimal amount, int boatId, int hours)
    {
        var client = new RazorpayClient("rzp_test_SbKo7vDDNwmVbm", "3HI7D9ZaxlJJppPoZBWqTHMM");

        Dictionary<string, object> options = new Dictionary<string, object>();
        options.Add("amount", amount * 100);
        options.Add("currency", "INR");

        Order order = client.Order.Create(options);

        ViewBag.OrderId = order["id"].ToString();
        ViewBag.Amount = amount;

        ViewBag.BoatId = boatId;
        ViewBag.Hours = hours;

        return View();
    }

    [HttpGet]
    public IActionResult Success(int boatId, int hours, decimal amount)
    {
        var booking = new Booking
        {
            BoatId = boatId,
            Hours = hours,
            TotalAmount = amount
        };

        _context.Bookings.Add(booking);
        _context.SaveChanges();

        return Ok();
    }
}