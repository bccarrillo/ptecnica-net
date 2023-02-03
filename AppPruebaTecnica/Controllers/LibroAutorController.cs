using Microsoft.AspNetCore.Mvc;
using AppPruebaTecnica.Models;
using AppPruebaTecnica.Controllers;
using AppPruebaTecnica.Models.ViewModels;
using System.Linq;

namespace AppPruebaTecnica.Controllers
{
    public class LibroAutorController : Controller
    {
        public async Task<IActionResult> Index(int? id)
        {
            // Objeto para traer datos de tablas libros y Autores

            DbA93584DemoContext obj = new DbA93584DemoContext();
            var myModel = new LibroAutorViewModel();
            //myModel.Librosss = obj.Libros.ToList();
            myModel.Librosss = obj.Libros.Where(x => x.Id == id).ToList();
            // myModel.Autoresss = obj.Autores.ToList();
            //myModel.Autoresss  = obj.Autores.Where(x => x.Nombre == "Carmen").ToList();

            List<LibAutViewModel> content = null;
            using (var dc = new DbA93584DemoContext())
            {
                content = (from aa in obj.Autores
                           join al in obj.AutoresHasLibros on aa.Id equals al.AutoresId
                           where al.LibrosId == id
                           orderby aa.Nombre
                           select new LibAutViewModel
                           {
                               IdA = aa.Id,
                               NombreA = aa.Nombre,
                               ApellidoA = aa.Apellidos,
                               IdL = (int)al.LibrosId
                           }).ToList();
            }

            myModel.LibAutVM = content;



            return View(myModel);
        }
    }
}
