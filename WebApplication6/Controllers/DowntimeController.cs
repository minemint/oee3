using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Models;
using WebApplication6.ViewModels;

namespace WebApplication6.Controllers
{
    public class DowntimeController : Controller
    {
        private readonly DBOEEContext _context;

        public DowntimeController(DBOEEContext context)
        {
            _context = context;
        }
        // GET: DowntimeController
        public ActionResult Index()
        {   
            var downtime = from o in _context.Outputs
                           from d in _context.Downtimes
                           from dc in _context.Dcode
                           from m in _context.Machines
                           from t in _context.Times
                           where o.OutputId == d.OutputId && d.DcodeId == dc.DcodeId && o.MachineId == m.MachineId && o.TimeId == t.TimeId
                           select new OutputViewModel
                           {    
                               OutputDate = o.OutputDate,
                               Tstart = t.Tstart,
                               Tend = t.Tend,
                               Shift = t.Shift,
                               OutputId = o.OutputId,
                               MachineNo = m.MachineNo,
                               DowntimeStart = d.DowntimeStart,
                               DowntimeEnd = d.DowntimeEnd,
                               DowntimeHour = d.DowntimeHour,
                               DcodeName = dc.DcodeName
                           };
            return View(downtime);
        }

        // GET: DowntimeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DowntimeController/Create
        public ActionResult Create(int outputId)
        {
            ViewBag.MachineId = outputId;
            ViewBag.DcodeId = new SelectList(_context.Dcode, "DcodeId", "DcodeName");
            ViewBag.OutputId = new SelectList(_context.Outputs, "OutputId", "OutputId");
            return View();
        }

        // POST: DowntimeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Downtimes downtimes)
        {

            if (ModelState.IsValid)
            {
                _context.Downtimes.Add(downtimes);
                _context.SaveChangesAsync();
            }

            ViewBag.DCodeId = new SelectList(_context.Dcode, "DCodeId", "DCodeName", downtimes.DcodeId);
            ViewBag.OutputId = new SelectList(_context.Outputs, "OutputId", "OutputId", downtimes.OutputId);
            return View(downtimes);
        }

        // GET: DowntimeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DowntimeController/Edit/5
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

        // GET: DowntimeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DowntimeController/Delete/5
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
