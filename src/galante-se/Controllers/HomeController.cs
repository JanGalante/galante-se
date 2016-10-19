using galante_se.ViewModels;
using galante_se.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace galante_se.Controllers
{
    public class HomeController : Controller
    {
        private IGreeter _greeter;
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
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
            //var model = _restaurantData.GetAll();
            var model = new HomePageViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.Greeting = _greeter.GetGreeting();

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                //return NotFound();
                //return NoContent(); < -Http error code 204
                //return BadRequest(); < -Http error code 400
                //return Unauthorized(); < -Http error code 401
                //return NotFound(); < -Http error code 404

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
