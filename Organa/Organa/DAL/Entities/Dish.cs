using System.ComponentModel.DataAnnotations;

namespace Organa.DAL.Entities
{
    public class Dish : Entity
    {
        
        [Display(Name = "Nombre plato")]
        [MaxLength(30, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        [Display(Name = "Categoría")] //Me gustaria cambiar esto por una clase que albergue los 3 tipos de categorias de platos disponibles con su respectiva descripción
        public int Category { get; set; }

        [Display(Name = "Imagen")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Image { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(1000, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Description { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public double Value { get; set; }

        [Display(Name = "Ingredientes")]      
        public ICollection<Ingredient> Ingredients { get; set; } //Un plato puede tener N ingredientes

    }
}
