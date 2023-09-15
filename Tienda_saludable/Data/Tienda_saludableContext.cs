using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TiendaSaludable.Modelos;

namespace Tienda_saludable.Data
{
    public class Tienda_saludableContext : DbContext
    {
        public Tienda_saludableContext (DbContextOptions<Tienda_saludableContext> options)
            : base(options)
        {
        }

        public DbSet<TiendaSaludable.Modelos.Cliente> Cliente { get; set; } = default!;

        public DbSet<TiendaSaludable.Modelos.Productos>? Productos { get; set; }

        public DbSet<TiendaSaludable.Modelos.Venta>? Venta { get; set; }
    }
}
