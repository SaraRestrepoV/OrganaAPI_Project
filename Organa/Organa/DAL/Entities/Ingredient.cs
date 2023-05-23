using System.ComponentModel.DataAnnotations;

namespace Organa.DAL.Entities
{
    public class Ingredient : Entity
    {
        
        [Display(Name = "Nombre ingrediente")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }
    }
}
