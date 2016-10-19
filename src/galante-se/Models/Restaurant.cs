using System.ComponentModel.DataAnnotations;

namespace galante_se.Models
{
    public class Restaurant
    {

        public int Id { get; set; }

        [Required, MaxLength(80)]
        [Display(Name = "Restaurant name")]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
