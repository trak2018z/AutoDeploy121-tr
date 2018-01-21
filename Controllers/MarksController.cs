using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aplikacja121.Data;

namespace Aplikacja121.Controllers
{
    public class MarksController : Controller
    {
        private readonly Aplikacja121dbContext _context;

        public MarksController(Aplikacja121dbContext context)
        {
            _context = context;
        }

        // GET: Marks
        public async Task<IActionResult> Index()
        {
            var aplikacja121dbContext = _context.Mark.Include(m => m.Student);
            return View(await aplikacja121dbContext.ToListAsync());
        }

        // GET: Marks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mark = await _context.Mark
                .Include(m => m.Student)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (mark == null)
            {
                return NotFound();
            }

            return View(mark);
        }

        // GET: Marks/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id");
            return View();
        }

        // POST: Marks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Value,Description,StudentId")] Mark mark)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mark);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", mark.StudentId);
            return View(mark);
        }

        // GET: Marks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mark = await _context.Mark.SingleOrDefaultAsync(m => m.Id == id);
            if (mark == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", mark.StudentId);
            return View(mark);
        }

        // POST: Marks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Value,Description,StudentId")] Mark mark)
        {
            if (id != mark.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mark);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarkExists(mark.Id))
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
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", mark.StudentId);
            return View(mark);
        }

        // GET: Marks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mark = await _context.Mark
                .Include(m => m.Student)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (mark == null)
            {
                return NotFound();
            }

            return View(mark);
        }

        // POST: Marks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mark = await _context.Mark.SingleOrDefaultAsync(m => m.Id == id);
            _context.Mark.Remove(mark);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarkExists(int id)
        {
            return _context.Mark.Any(e => e.Id == id);
        }
    }
}
