using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using galante_se.Models;

namespace galante_se.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "La Rambla" },
                new Restaurant { Id = 2, Name = "Byn" },
                new Restaurant { Id = 3, Name = "Bistro Sud" },
                new Restaurant { Id = 4, Name = "Paladar" }
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }
    }
}
