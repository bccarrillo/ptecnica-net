using AppPruebaTecnica.Models;

namespace AppPruebaTecnica.Models.ViewModels
{
    public class LibroAutorViewModel
    {
        public IEnumerable<Libro> Librosss { get; set; }
        public IEnumerable<Autore> Autoresss { get; set; }
        public IEnumerable<AutoresHasLibro> AutoHasLibro { get; set; }
        public IEnumerable<LibAutViewModel> LibAutVM { get; set; }
    }
}
