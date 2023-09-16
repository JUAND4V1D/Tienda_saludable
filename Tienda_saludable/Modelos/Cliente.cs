using System.ComponentModel.DataAnnotations;

namespace TiendaSaludable.Modelos
{
    public class Cliente
    {
        //CREACION DE LOS ATRIBUTOS 
        public int ID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefono { get; set; }
    }

}
