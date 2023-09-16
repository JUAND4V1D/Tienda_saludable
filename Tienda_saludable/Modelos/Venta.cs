using System.ComponentModel.DataAnnotations;

namespace TiendaSaludable.Modelos
{
    public class Venta
    {
        public int ID { get; set; }
        [Required]
        public int ClienteID { get; set; }
        [Required]
        public Cliente? Cliente { get; set; }
        [Required]
        public DateTime FechaVenta { get; set; }
        [Required]
        public List<Productos>? Productos { get; set; }
        [Required]
        public decimal TotalVenta { get; set; }
    }

}
