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
    public class DeleteModel : PageModel
    {
        private readonly Tienda_saludable.Data.Tienda_saludableContext _context;

        public DeleteModel(Tienda_saludable.Data.Tienda_saludableContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Venta Venta { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Venta == null)
            {
                return NotFound();
            }

            var venta = await _context.Venta.FirstOrDefaultAsync(m => m.ID == id);

            if (venta == null)
            {
                return NotFound();
            }
            else 
            {
                Venta = venta;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Venta == null)
            {
                return NotFound();
            }
            var venta = await _context.Venta.FindAsync(id);

            if (venta != null)
            {
                Venta = venta;
                _context.Venta.Remove(Venta);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
