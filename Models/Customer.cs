using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SupermarketWEB.Models

{
    public class Customer
    {
        public int Id { get; set; } // Será la llave primaria

        [Required]
        [Display(Name= "Document Number")]
        [MaxLength(15)]
        public string DocumentNumber { get; set; } // Número de documento

        [Required]
        [Display(Name = "First Name")]
        [MaxLength(50)]
        public string FirstName { get; set; } // Nombre

        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(50)]
        public string LastName { get; set; } // Apellido

        [Display(Name = "Address")]
        public string? Address { get; set; } // Dirección

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; } // Fecha de nacimiento

        [Display(Name = "Phone Number")]
        [MaxLength(50)]
        public string? Phone { get; set; }  // Número de teléfono

        [EmailAddress]
        [MaxLength(100)]

        public string? Email { get; set; }  // Correo electrónico
    }
}
