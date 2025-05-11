using System.ComponentModel.DataAnnotations;

namespace SupermarketWEB.Models
{
    public class PayMode
    {
        public int Id { get; set; } // Llave primaria

        [Required]
        [MaxLength(80)]
        public string Name { get; set; } // Nombre del modo de pago

        [MaxLength(300)]
        public string? Observation { get; set; } // Observaciones del modo de pago
    }
}
