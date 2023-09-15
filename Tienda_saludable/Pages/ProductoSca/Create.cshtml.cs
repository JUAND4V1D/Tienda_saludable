using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TiendaSaludable.Modelos;
using Tienda_saludable.Data;

namespace Tienda_saludable.Pages.ProductoSca
{
    public class CreateModel : PageModel
    {
        private readonly Tienda_saludable.Data.Tienda_saludableContext _context;

        public CreateModel(Tienda_saludable.Data.Tienda_saludableContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Productos Productos { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Productos == null || Productos == null)
            {
                return Page();
            }

            _context.Productos.Add(Productos);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
