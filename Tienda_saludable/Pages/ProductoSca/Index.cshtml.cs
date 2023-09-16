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

namespace Tienda_saludable.Pages.ProductoSca
{
    public class IndexModel : PageModel
    {
        private readonly Tienda_saludable.Data.Tienda_saludableContext _context;

        public IndexModel(Tienda_saludable.Data.Tienda_saludableContext context)
        {
            _context = context;
        }

        public IList<Productos> Productos { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Nombre { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? NombreProducto { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Preco { get; set; }



        [BindProperty(SupportsGet = true)]
        public string? Search_verdura { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Searc_Fruta { get; set; }


        public SelectList? Verdura { get; set; }
        public SelectList? Fruta { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> productNameQuery = from p in _context.Productos
                                                  orderby p.Nombre
                                                  select p.Nombre;
            var productos = from p in _context.Productos
                            select p;


            if (!string.IsNullOrEmpty(SearchString))
            {
                productos = productos.Where(p => p.Nombre.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(NombreProducto))
            {
                if (NombreProducto == "InStock")
                {
                    productos = productos.Where(p => p.Stock > 0);
                }

                else if (NombreProducto == "Search_verdura")
                {
                    productos = productos.Where(p => p.Descripcion.Contains("Verdura"));
                }
                else if (NombreProducto == "Searc_Fruta")
                {
                    productos = productos.Where(p => p.Descripcion.Contains("Fruta"));
                }
                else
                {
                    productos = productos.Where(p => p.Nombre == NombreProducto);
                }
            }

            if (Preco > 0)
            {
                productos = productos.Where(p => p.Precio == Preco);
            }



            Nombre = new SelectList(await productNameQuery.Distinct().ToListAsync());
            Productos = await productos.ToListAsync();
            //Verdura = new SelectList(await productos.Where(p => p.Descripcion == "Verdura").ToListAsync());

        }
    }
}
