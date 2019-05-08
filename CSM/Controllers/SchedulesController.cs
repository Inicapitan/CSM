using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSM.Data;
using CSM.Models;

namespace CSM.Controllers
{
    public class SchedulesController : Controller
    {
        private readonly CsmContext _context;

        public SchedulesController(CsmContext context)
        {
            _context = context;
        }

        // GET: Schedules
        public async Task<IActionResult> Index()
        {
            List<Schedule> fullschedule = new List<Schedule>();
            var schedule = await _context.Schedule.ToListAsync();
            foreach(var s in schedule)
            {
                s.Client = await _context.Client.FirstOrDefaultAsync(c => c.ID == s.ClientID);
                s.Service = await _context.Service.FirstOrDefaultAsync(ser => ser.ID == s.ServiceID);
                fullschedule.Add(s);
            }


            return View(fullschedule);
        }

        // GET: Schedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule.FirstOrDefaultAsync(m => m.ID == id);
            schedule.Client = await _context.Client.FirstOrDefaultAsync(c => c.ID == schedule.ClientID);
            schedule.Service = await _context.Service.FirstOrDefaultAsync(s => s.ID == schedule.ServiceID);

            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // GET: Schedules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ClientID,ServiceID,Payed,Date")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(schedule);
        }

        // GET: Schedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            return View(schedule);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ClientID,ServiceID,Payed,Date")] Schedule schedule)
        {
            if (id != schedule.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleExists(schedule.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(schedule);
        }

        // GET: Schedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule
                .FirstOrDefaultAsync(m => m.ID == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schedule = await _context.Schedule.FindAsync(id);
            _context.Schedule.Remove(schedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Schedule()
        {
            List<Schedule> fullschedule = new List<Schedule>();
            List<CalendarEvent> events = new List<CalendarEvent>();

            var schedule = await _context.Schedule.ToListAsync();
            foreach (var s in schedule)
            {
                s.Client = await _context.Client.FirstOrDefaultAsync(c => c.ID == s.ClientID);
                s.Service = await _context.Service.FirstOrDefaultAsync(ser => ser.ID == s.ServiceID);
                fullschedule.Add(s);

                var title = string.Format("{0} {1} // {2}",s.Client.Name,s.Client.Surname,s.Service.Name);
                var evento = new CalendarEvent { Title=title, Date=s.Date, Type="info"};
                events.Add(evento);

            }


            return View(events);
        }
        private bool ScheduleExists(int id)
        {
            return _context.Schedule.Any(e => e.ID == id);
        }
    }
}
