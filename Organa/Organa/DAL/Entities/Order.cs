using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Organa.DAL.Entities
{
    public class Order : Entity
    {

        [Display(Name = "Estado pedido")]
        public int status { get; set; }

        [Display(Name = "Detalles")]
        public string details { get; set; } 

        [Display(Name = "Valor")]
        public double value { get; set; }

        //Foráneas
        [Display(Name = "Cliente ID")]
        [Required]
        public string clientId { get; set; }

        [Required]
        [Display(Name = "Platos")]
        public ICollection<Dish> Dishes { get; set; } //Una orden puede tener N platos

    }
}
