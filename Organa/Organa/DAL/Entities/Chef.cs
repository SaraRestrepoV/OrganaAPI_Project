using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Organa.DAL.Entities
{
    public class Chef : EntityUsers
    {

        [Key]
        [Display(Name = "Documento identidad")]
        [MaxLength(10, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        public string idChef { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string firstNameChef { get; set; }

        [Display(Name = "Apellido")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string lastNameChef { get; set; }

        [Display(Name = "Correo electrónico")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        public string emailChef { get; set; }

        [Display(Name = "Teléfono")]
        [MaxLength(15, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string phoneChef { get; set; }
    }
}
