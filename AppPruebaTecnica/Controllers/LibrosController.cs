using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppPruebaTecnica.Models;
using AppPruebaTecnica.Models.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AppPruebaTecnica.Controllers
{
    [Authorize]
    public class LibrosController : Controller
    {
        private readonly DbA93584DemoContext _context;

        public LibrosController(DbA93584DemoContext context)
        {
            _context = context;
        }

        // GET: Libros  Muestra lidato de entidad libros
        public async Task<IActionResult> Index()
        {

           
            using (var ctx = new DbA93584DemoContext())
            {
                 var query = from a in ctx.Libros
                            join s in ctx.Editoriales on a.EditorialesId equals s.Id
                            select new LibroEditorial
                            {
                                Id = a.Id,
                                titulo = a.Titulo,
                                description = a.Sinopsis,
                                nropaginas = a.NPaginas,
                                nombreditorial = s.Nombre
                            };
                return View(await query.ToListAsync());
            }

            //return View(await _context.Libros.ToListAsync());
            
        }

        // GET: Libros/Details/5   detalle de un libro
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Libros == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libros/Create   
        public IActionResult Create()
        {
            List<SelectListItem> items = LoadCBEditorial();
            ViewBag.Items = items;
            return View();
        }

        // POST: Libros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EditorialesId,Titulo,Sinopsis,NPaginas")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                /// Agrega en BD datos del libro 
                _context.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
        }

        // GET: Libros/Edit/5  Muestra informacion de un libro para Edicion
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Libros == null)
            {
                return NotFound();
            }

            List<SelectListItem> items = LoadCBEditorial();
            ViewBag.Items = items;

            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        // POST: Libros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EditorialesId,Titulo,Sinopsis,NPaginas")] Libro libro)
        {
            if (id != libro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.Id))
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
            return View(libro);
        }

        // GET: Libros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Libros == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Libros == null)
            {
                return Problem("Entity set 'DbA93584DemoContext.Libros'  is null.");
            }
            var libro = await _context.Libros.FindAsync(id);
            if (libro != null)
            {
                _context.Libros.Remove(libro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
          return _context.Libros.Any(e => e.Id == id);
        }

        private List<SelectListItem> LoadCBEditorial()
        {
            List<EditorialViewModel> lst = null;
            using (Models.DbA93584DemoContext db = new Models.DbA93584DemoContext())
            {
                lst = (from d in db.Editoriales
                       select new EditorialViewModel
                       {
                           Id = d.Id,
                           Nombre = d.Nombre
                       }).ToList();
            }

            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            return items;
        }

        private List<SelectListItem> LoadCBAutores()
        {
            List<Autore> lst = null;
            using (Models.DbA93584DemoContext db = new Models.DbA93584DemoContext())
            {
                lst = (from d in db.Autores
                       select new Autore
                       {
                           Id = d.Id,
                           Nombre = d.Nombre + " " + d.Apellidos
                       }).ToList();
            }

            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            return items;
        }

    }
}
