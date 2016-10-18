using galante_se.Models;
using galante_se.Services;
using Microsoft.AspNetCore.Mvc;

namespace galante_se.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        //public IActionResult Index()
        //{
        //    return Content("Hello, from a controller");
        //}


        /// <summary>
        /// Action that returns a json representation of a model/restaurant.
        /// This is a common way to use in api:s
        /// </summary>
        /// <returns></returns>
        //public ObjectResult Index()
        //{
        //    var model = new Restaurant { Id = 1, Name = "La Rambla" };
        //    return new ObjectResult(model); //Serilize (xml/json/...) the object based on configuration or default to json
        //}

      
        public ViewResult Index()
        {
            //var model = new Restaurant { Id = 1, Name = "La Rambla" };
            var model = _restaurantData.GetAll();
            return View(model);
        }
    }
}
