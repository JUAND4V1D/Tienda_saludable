using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TiendaSaludable.Modelos;
using Tienda_saludable.Data;

namespace Tienda_saludable.Pages.VentaSca
{
    public class IndexModel : PageModel
    {
        private readonly Tienda_saludable.Data.Tienda_saludableContext _context;

        public IndexModel(Tienda_saludable.Data.Tienda_saludableContext context)
        {
            _context = context;
        }

        public IList<Venta> Venta { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var ventasQuery = _context.Venta
                .Include(v => v.Cliente)
                .Include(v => v.Productos)
                .AsQueryable();

            

            if (!string.IsNullOrEmpty(SearchString))
            {
                ventasQuery = ventasQuery.Where(v => v.Productos.Any(p => p.Nombre.Contains(SearchString)));
            }

            Venta = await ventasQuery.ToListAsync();
        }
    }
}

