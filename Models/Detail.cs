using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupermarketWEB.Models
{
    public class Detail
    {
        public int Id { get; set; } // Llave primaria

        [Required]
        [Display(Name = "Invoice")]
        public int InvoiceId { get; set; }

        [Required]
        [Display(Name = "Product")]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }

        // Relaciones
        public Invoice? Invoice { get; set; }
        public Product? Product { get; set; }
    }
}
