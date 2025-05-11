using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SupermarketWEB.Models
{
    public class Invoice
    {
        public int Id { get; set; } //Llave primaria

        [Required]
        public int Number { get; set; } //Número de factura

        [Required]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; } //Llave foránea

        [Required]
        [Display(Name = "Pay Mode")]
        public int PayModeId { get; set; } //Llave foránea

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        //Relaciones
        public Customer? Customer { get; set; } //Propiedad de navegación

        public PayMode? PayMode { get; set; } //Propiedad de navegación
    }
}
