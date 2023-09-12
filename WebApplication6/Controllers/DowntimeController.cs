using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
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
            var downtime = from d in _context.Downtimes 
                           join o in _context.Outputs on d.OutputId equals o.OutputId into downtimeGroup
                           from o in downtimeGroup.DefaultIfEmpty()
                           join dc in _context.Dcode on d.DcodeId equals dc.DcodeId into dcodeGroup
                           from dc in dcodeGroup.DefaultIfEmpty()
                           join m in _context.Machines on o.MachineId equals m.MachineId into MachineGroup
                           from m in MachineGroup.DefaultIfEmpty()
                           join t in _context.Times on o.TimeId equals t.TimeId into TimeGroup
                           from t in TimeGroup.DefaultIfEmpty()
                           select new OutputViewModel
                           {    
                               DownTimeId = d.DowntimeId,
                               OutputDate = o.OutputDate,
                               Tstart = t.Tstart,
                               Tend = t.Tend,
                               Shift = t.Shift,
                               OutputId = o.OutputId,
                               MachineNo = m.MachineNo,
                               DowntimeStart = d.DowntimeStart,
                               DowntimeEnd = d.DowntimeEnd,
                               DowntimeHour = d.DowntimeHour,
                               DcodeName = dc.DcodeName,
                               DcodeId = dc.DcodeId
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
            ViewBag.OutputId = outputId;
            ViewBag.DcodeId = new SelectList(_context.Dcode, "DcodeId", "DcodeName");
            ViewBag.OutputId = new SelectList(_context.Outputs, "OutputId", "OutputId");
            return View();
        }

        // POST: DowntimeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Downtimes downtimes ,int outputId)
        {
            var x = downtimes.DowntimeStart;

            if (ModelState.IsValid)
            {
                _context.Downtimes.Add(downtimes);
                _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Downtime Added Successfully";
            }
            //ViewBag.OutputId = outputId;
            ViewBag.DCodeId = new SelectList(_context.Dcode, "DcodeId", "DcodeName", downtimes.DcodeId);
            ViewBag.OutputId = new SelectList(_context.Outputs, "OutputId", "OutputId", downtimes.OutputId);
            return RedirectToAction(nameof(Index));
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
        public ActionResult Result(string searchByMachine, DateTime SearchByDate)
        {
            //System.Globalization.CultureInfo cultureinfo = new CultureInfo("en-US");
            //DateTime date = DateTime.ParseExact(SearchByDate.ToString("dd/MM/yyyy"), "dd/MM/yyyy", cultureinfo);
            //TempData["SearchByDate"] = date;
            //TempData["SearchByMachine"] = searchByMachine;
          
            var downtime = from d in _context.Downtimes
                            join o in _context.Outputs on d.OutputId equals o.OutputId into downtimeGroup
                            from o in downtimeGroup.DefaultIfEmpty()
                            join dc in _context.Dcode on d.DcodeId equals dc.DcodeId into dcodeGroup
                            from dc in dcodeGroup.DefaultIfEmpty()
                            join m in _context.Machines on o.MachineId equals m.MachineId into MachineGroup
                            from m in MachineGroup.DefaultIfEmpty()
                            join t in _context.Times on o.TimeId equals t.TimeId into TimeGroup
                            from t in TimeGroup.DefaultIfEmpty()
                            where (m.MachineNo.Contains(searchByMachine) && searchByMachine == "DADS Lites No.01") || (o.OutputDate == SearchByDate || SearchByDate == DateTime.Now)
                            select new OutputViewModel
                            {
                                DownTimeId = d.DowntimeId,
                                OutputDate = o.OutputDate,
                                Tstart = t.Tstart,
                                Tend = t.Tend,
                                Shift = t.Shift,
                                OutputId = o.OutputId,
                                MachineNo = m.MachineNo,
                                DowntimeStart = d.DowntimeStart,
                                DowntimeEnd = d.DowntimeEnd,
                                DowntimeHour = d.DowntimeHour,
                                DcodeName = dc.DcodeName,
                                DcodeId = dc.DcodeId
                            };
            return View(downtime);
        }
    }

}

