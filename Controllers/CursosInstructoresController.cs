using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EjemploMVCCursosOnline.Data;
using EjemploMVCCursosOnline.Models;

namespace EjemploMVCCursosOnline.Controllers
{
    public class CursosInstructoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CursosInstructoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CursosInstructores
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CursoInstructor.Include(c => c.Curso).Include(c => c.Instructor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CursosInstructores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoInstructor = await _context.CursoInstructor
                .Include(c => c.Curso)
                .Include(c => c.Instructor)
                .FirstOrDefaultAsync(m => m.CursoId == id);
            if (cursoInstructor == null)
            {
                return NotFound();
            }

            return View(cursoInstructor);
        }

        // GET: CursosInstructores/Create
        public IActionResult Create()
        {
            ViewData["CursoId"] = new SelectList(_context.Curso, "Id", "Titulo");
            ViewData["InstructorId"] = new SelectList(_context.Instructor, "Id", "NombreCompleto");
            return View();
        }

        // POST: CursosInstructores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CursoId,InstructorId")] CursoInstructor cursoInstructor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursoInstructor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoId"] = new SelectList(_context.Curso, "Id", "Descripcion", cursoInstructor.CursoId);
            ViewData["InstructorId"] = new SelectList(_context.Instructor, "Id", "Cargo", cursoInstructor.InstructorId);
            return View(cursoInstructor);
        }

        // GET: CursosInstructores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoInstructor = await _context.CursoInstructor.FindAsync(id);
            if (cursoInstructor == null)
            {
                return NotFound();
            }
            ViewData["CursoId"] = new SelectList(_context.Curso, "Id", "Descripcion", cursoInstructor.CursoId);
            ViewData["InstructorId"] = new SelectList(_context.Instructor, "Id", "Cargo", cursoInstructor.InstructorId);
            return View(cursoInstructor);
        }

        // POST: CursosInstructores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CursoId,InstructorId")] CursoInstructor cursoInstructor)
        {
            if (id != cursoInstructor.CursoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cursoInstructor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoInstructorExists(cursoInstructor.CursoId))
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
            ViewData["CursoId"] = new SelectList(_context.Curso, "Id", "Descripcion", cursoInstructor.CursoId);
            ViewData["InstructorId"] = new SelectList(_context.Instructor, "Id", "Cargo", cursoInstructor.InstructorId);
            return View(cursoInstructor);
        }

        // GET: CursosInstructores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoInstructor = await _context.CursoInstructor
                .Include(c => c.Curso)
                .Include(c => c.Instructor)
                .FirstOrDefaultAsync(m => m.CursoId == id);
            if (cursoInstructor == null)
            {
                return NotFound();
            }

            return View(cursoInstructor);
        }

        // POST: CursosInstructores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cursoInstructor = await _context.CursoInstructor.FindAsync(id);
            _context.CursoInstructor.Remove(cursoInstructor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoInstructorExists(int id)
        {
            return _context.CursoInstructor.Any(e => e.CursoId == id);
        }
    }
}
