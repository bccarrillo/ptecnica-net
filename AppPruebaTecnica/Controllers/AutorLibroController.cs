using AppPruebaTecnica.Models.ViewModels;
using AppPruebaTecnica.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppPruebaTecnica.Controllers
{
    public class AutorLibroController : Controller
    {
        public async Task<IActionResult>  Index(int? id)
        {
            // Objeto para traer datos de tablas Autores libros 

            DbA93584DemoContext obj = new DbA93584DemoContext();
            var myModel = new LibroAutorViewModel();
            //myModel.Librosss = obj.Libros.ToList();
            //myModel.Librosss = obj.Libros.Where(x => x.Id == id).ToList();
            myModel.Autoresss = obj.Autores.Where(x => x.Id == id).ToList();
            //myModel.Autoresss  = obj.Autores.Where(x => x.Nombre == "Carmen").ToList();

            List<LibAutViewModel> content = null;
            using (var dc = new DbA93584DemoContext())
            {
                content = (from li in obj.Libros
                           join al in obj.AutoresHasLibros on li.Id equals al.LibrosId
                           where al.AutoresId == id
                           orderby li.Titulo
                           select new LibAutViewModel
                           {
                               IdA = li.Id,
                               NombreA = li.Titulo,
                               ApellidoA = li.NPaginas,
                               IdL = (int)al.LibrosId
                           }).ToList();
            }

            myModel.LibAutVM = content;



            return View(myModel);
        }
    }
}
