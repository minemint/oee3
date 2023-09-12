using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class GenOutputController : Controller
    {
        private readonly DBOEEContext _context;

        public GenOutputController(DBOEEContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GenData() {

            _context.Database.ExecuteSqlRaw("EXECUTE dbo.GenerateOutput3");
            TempData["AlertMessage"] = "Output Added Successfully";
            return RedirectToAction("Index","Output");
        }
    }
}
