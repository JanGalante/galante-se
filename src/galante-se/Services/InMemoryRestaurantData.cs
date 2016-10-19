using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using galante_se.Models;
using System.Linq;

namespace galante_se.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private static List<Restaurant> _restaurants;

        static InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "La Rambla" },
                new Restaurant { Id = 2, Name = "Byn" },
                new Restaurant { Id = 3, Name = "Bistro Sud" },
                new Restaurant { Id = 4, Name = "Paladar" }
            };
        }

        public void Add(Restaurant restaurant)
        {
            //restaurant.Id = _restaurants.Max(restaurants => restaurant.Id) + 1;
            restaurant.Id = _restaurants.OrderByDescending(r => r.Id).FirstOrDefault().Id + 1;
            _restaurants.Add(restaurant);
        }

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(restaurant => restaurant.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }
    }
}
