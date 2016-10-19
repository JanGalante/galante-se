using galante_se.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace galante_se.ViewModels.InputViewModels
{
    /// <summary>
    /// This model only contains the properties we expect to get via the http request
    /// </summary>
    public class RestaurantEditViewModel
    {
        [Required, MaxLength(80)]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
