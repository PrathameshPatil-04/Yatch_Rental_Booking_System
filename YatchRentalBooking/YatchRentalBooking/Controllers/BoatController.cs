using Microsoft.AspNetCore.Mvc;
using YachtRentalBooking.Models;
using YachtRentalMVC.Data;

public class BoatController : Controller
{
    private readonly AppDbContext _context;

    public BoatController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Boats.ToList());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Boat boat, IFormFile ImageFile)
    {
        if (ImageFile != null)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(ImageFile.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                ImageFile.CopyTo(stream);
            }

            boat.ImagePath = "/images/" + fileName;
        }

        _context.Boats.Add(boat);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var boat = _context.Boats.Find(id);
        return View(boat);
    }

    [HttpPost]
    public IActionResult Edit(Boat boat)
    {
        _context.Boats.Update(boat);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var boat = _context.Boats.Find(id);
        _context.Boats.Remove(boat);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}