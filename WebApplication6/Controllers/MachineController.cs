using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Reflection.PortableExecutable;
using WebApplication6.Models;
using WebApplication6.ViewModels;

namespace WebApplication6.Controllers
{
    public class MachineController : Controller
    {
        private readonly DBOEEContext _context;

        public MachineController(DBOEEContext context)
        {
            _context = context;
        }

        // GET: MachineController
        public ActionResult Index()
        {   
            var machine = _context.Machines;
            return View(machine);
        }

        // GET: MachineController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MachineController/Create
        public ActionResult Create()
        {   
            return View();
        }

        // POST: MachineController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Machines Machine)
        {
            try
            {
                _context.Machines.Add(Machine);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MachineController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MachineController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: MachineController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MachineController/Delete/5
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

        public ActionResult Result(string searchByMachine, DateTime SearchByDate)
        {
            TempData["SearchByMachine"] = searchByMachine;
            var machine = (from m in _context.Machines
                           where m.MachineNo.Contains(searchByMachine) 
                           select new OutputViewModel
                           {
                               MachineNo = m.MachineNo,
                           }).ToList();
            return View(machine);
        }
    }
}
