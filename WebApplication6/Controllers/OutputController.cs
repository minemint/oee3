using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebApplication6.Models;
using WebApplication6.ViewModels;

namespace WebApplication6.Controllers
{
    public class OutputController : Controller
    {   
        private readonly DBOEEContext _context;

        public OutputController(DBOEEContext context)
        {
            _context = context;
        }

        // GET: OutputController
        public ActionResult Index()
        {   
            var outputs = _context.Outputs.Include(o => o.Defect).Include(o => o.Machine).Include(o => o.Time).Include(o => o.Toy) ;

            return View(outputs);
        }

        // GET: OutputController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OutputController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OutputController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OutputController/Edit/5
        public ActionResult Edit(int id)
        {

            Outputs outputs = _context.Outputs.Find(id);

            ViewBag.DefectId = new SelectList(_context.Defects, "DefectId", "DefectName", outputs.DefectId);
            ViewBag.MachineId = new SelectList(_context.Machines, "MachineId", "MachineNo", outputs.MachineId);
            ViewBag.TimeId = new SelectList(_context.Times, "TimeId", "Tstart", outputs.TimeId);
            ViewBag.ToyId = new SelectList(_context.Toys.OrderBy(n => n.ToyName), "ToyId", "ToyName", outputs.ToyId);
            return View(outputs);
        }

        // POST: OutputController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Outputs outputs)
        {   
            if(ModelState.IsValid)
            {
                _context.Entry(outputs).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DefectId = new SelectList(_context.Defects, "DefectId", "DefectName", outputs.DefectId);
            ViewBag.MachineId = new SelectList(_context.Machines, "MachineId", "MachineNo", outputs.MachineId);
            ViewBag.TimeId = new SelectList(_context.Times, "TimeId", "Tstart", outputs.TimeId);
            ViewBag.ToyId = new SelectList(_context.Toys, "ToyId", "ToyName", outputs.ToyId);
            return View(outputs);
        }

        // GET: OutputController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OutputController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
