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

namespace Tienda_saludable.Pages.ProductoSca
{
    public class EditModel : PageModel
    {
        private readonly Tienda_saludable.Data.Tienda_saludableContext _context;

        public EditModel(Tienda_saludable.Data.Tienda_saludableContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Productos Productos { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var productos =  await _context.Productos.FirstOrDefaultAsync(m => m.ID == id);
            if (productos == null)
            {
                return NotFound();
            }
            Productos = productos;
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

            _context.Attach(Productos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductosExists(Productos.ID))
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

        private bool ProductosExists(int id)
        {
          return (_context.Productos?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
