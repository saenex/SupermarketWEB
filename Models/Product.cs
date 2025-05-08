using System.ComponentModel.DataAnnotations.Schema;

namespace SupermarketWEB.Models
{
    public class Product
    {
        // [ Key ] -> Anotación si la propiedad nose llama Id, ejemplo ProductId
        public int Id { get; set; } //Será la llave primaria 
        public string Name { get; set; } // Nombre del producto

        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; } // Llave foránea
        public Category Category { get; set; } // Navegación a la tabla de categorías

    }
}