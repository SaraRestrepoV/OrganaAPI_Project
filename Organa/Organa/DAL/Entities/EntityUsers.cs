using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;

namespace Organa.DAL.Entities
{
    public class EntityUsers
    {
        [Display(Name = "Fecha de creación")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Fecha de actualización")]
        public DateTime? ModifiedDate { get; set; }

    }
}
