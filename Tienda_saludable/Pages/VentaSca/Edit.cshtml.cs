using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TiendaSaludable.Modelos;
using Tienda_saludable.Data;

namespace Tienda_saludable.Pages.VentaSca
{
    public class EditModel : PageModel
    {
        private readonly Tienda_saludable.Data.Tienda_saludableContext _context;

        public EditModel(Tienda_saludable.Data.Tienda_saludableContext context)
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

            var venta =  await _context.Venta.FirstOrDefaultAsync(m => m.ID == id);
            if (venta == null)
            {
                return NotFound();
            }
            Venta = venta;
           ViewData["ClienteID"] = new SelectList(_context.Cliente, "ID", "Apellido");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Venta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaExists(Venta.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VentaExists(int id)
        {
          return (_context.Venta?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
