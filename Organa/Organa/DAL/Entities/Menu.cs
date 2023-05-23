using System.ComponentModel.DataAnnotations;

namespace Organa.DAL.Entities
{
    public class Menu : Entity
    {

        [Display(Name = "Nombre menú")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(1000, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Description { get; set; }

        [Display(Name = "Platos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public ICollection<Dish> Dishes { get; set; } //Un menú puede tener N platos
        public int DishesNumber => Dishes == null ? 0 : Dishes.Count;

    }
}
