using System.ComponentModel.DataAnnotations;

namespace Organa.DAL.Entities
{
    public class Invoice : Entity
    {
        //Foraneas
        [Display(Name = "Pago Id")]
        public Guid payId { get; set; }
    }
}
