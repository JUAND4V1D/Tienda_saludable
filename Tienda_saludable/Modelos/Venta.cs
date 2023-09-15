using System.ComponentModel.DataAnnotations;

namespace TiendaSaludable.Modelos
{
    public class Venta
    {
        public int ID { get; set; }
        public int ClienteID { get; set; } // Referencia al cliente que realizó la compra
        [Required]
        public DateTime FechaVenta { get; set; }
        [Required]
        public List<Productos> Productos { get; set; } // Lista de productos vendidos en esta venta
        [Required]
        public decimal TotalVenta { get; set; }
    }
}
