using System.ComponentModel.DataAnnotations;

namespace Organa.DAL.Entities
{
    public class Pay : Entity
    {
        [Required]
        [Display(Name = "Valor")]
        public double value {  get; set; }

        //Foraneas
        [Display(Name = "Orden Id")]
        public Guid orderId { get; set; }
    }
}
