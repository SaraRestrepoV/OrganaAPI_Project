using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Organa.DAL.Entities
{
    public class Receipt : Entity
    {
        [Display(Name = "Detalles")]
        public string details { get; set; }

        [Display(Name = "Estado")]
        public string status { get; set; }

        [Display(Name = "Valor")]
        public double value { get; set; }

        //Foraneas
        [Display(Name = "Orden Id")]
        public Guid orderId { get; set; }
    }
}
