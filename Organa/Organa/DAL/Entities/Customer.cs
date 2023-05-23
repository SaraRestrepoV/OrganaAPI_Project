using System.ComponentModel.DataAnnotations;
using System.IO.Pipes;
using System.Security.Policy;

namespace Organa.DAL.Entities
{
    public class Customer : EntityUsers
    {
        [Key]
        [Display(Name = "Documento identidad")]
        [MaxLength(10, ErrorMessage = "El campo {0} debe tener como máximo {1} caracteres")]
        public string customerId { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener como máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string firstName{ get; set; }

        [Display(Name = "Apellido")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener como máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string lastName { get; set; }

        [Display(Name = "Correo electrónico")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener como máximo {1} caracteres")]
        public string email { get; set; }

        [Display(Name = "Teléfono")]
        [MaxLength(15, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string phone { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string address { get; set; }

    }
}
