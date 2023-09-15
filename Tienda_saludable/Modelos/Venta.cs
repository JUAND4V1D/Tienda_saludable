using System.ComponentModel.DataAnnotations;

namespace TiendaSaludable.Modelos
{
    public class Venta
    {
        public int ID { get; set; }
        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime FechaVenta { get; set; }
        public List<Productos> Productos { get; set; }
        public decimal TotalVenta { get; set; }
    }

}
