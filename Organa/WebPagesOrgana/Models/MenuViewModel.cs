using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebPagesOrgana.Models
{
    public class MenuViewModel
    {
        [Display(Name = "Nombre menú")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(1000, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Description { get; set; }

        public int SelectedDishId { get; set; }

        [Display(Name = "Platos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public ICollection<DishViewModel> Dishes { get; set; } //Un menú puede tener N platos

    }
}
