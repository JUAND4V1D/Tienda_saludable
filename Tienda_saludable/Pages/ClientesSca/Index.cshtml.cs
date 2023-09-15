using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TiendaSaludable.Modelos;
using Tienda_saludable.Data;

namespace Tienda_saludable.Pages.ClientesSca
{
    public class IndexModel : PageModel
    {
        private readonly Tienda_saludable.Data.Tienda_saludableContext _context;

        public IndexModel(Tienda_saludable.Data.Tienda_saludableContext context)
        {
            _context = context;
        }

        public IList<Cliente> Cliente { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Cliente != null)
            {
                Cliente = await _context.Cliente.ToListAsync();
            }
        }
    }
}
