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
    public class DetailsModel : PageModel
    {
        private readonly Tienda_saludable.Data.Tienda_saludableContext _context;

        public DetailsModel(Tienda_saludable.Data.Tienda_saludableContext context)
        {
            _context = context;
        }

      public Cliente Cliente { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cliente == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FirstOrDefaultAsync(m => m.ID == id);
            if (cliente == null)
            {
                return NotFound();
            }
            else 
            {
                Cliente = cliente;
            }
            return Page();
        }
    }
}
