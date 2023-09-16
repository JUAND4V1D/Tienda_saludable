using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TiendaSaludable.Modelos;
using Tienda_saludable.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tienda_saludable.Pages.ClientesSca
{
    public class IndexModel : PageModel
    {
        private readonly Tienda_saludable.Data.Tienda_saludableContext _context;

        public IndexModel(Tienda_saludable.Data.Tienda_saludableContext context)
        {
            _context = context;
        }

        public IList<Cliente> Cliente { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList Email { get; set; }
        public SelectList? Nombre { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? ClienteNombre { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Cliente
                                            orderby m.Email
                                            select m.Email;
            var clientes = from m in _context.Cliente
                           select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                clientes = clientes.Where(s => s.Nombre.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ClienteNombre))
            {
                clientes = clientes.Where(x => x.Email == ClienteNombre);
            }
            Email = new SelectList(await genreQuery.Distinct().ToListAsync());

            Cliente = await clientes.ToListAsync();

        }
    }
}
