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
        public string DocumentNumber { get; set; } = string.Empty; // Número de documento

        [Required]
        [Display(Name = "First Name")]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty; // Nombre

        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty; // Apellido

        [DataType(DataType.Date)]
        public DateTime Birtday { get; set; } // Fecha de nacimiento

        [Display(Name = "Phone Number")]
        [MaxLength(50)]
        public string PhoneNumber { get; set; } = string.Empty; // Número de teléfono

        [EmailAddress]
        [MaxLength(100)]

        public string Email { get; set; } = string.Empty; // Correo electrónico
    }
}
