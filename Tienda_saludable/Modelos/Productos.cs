using System.ComponentModel.DataAnnotations;

namespace TiendaSaludable.Modelos
{
    public class Productos
    {
        public int ID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int Stock { get; set; }
    }
}
