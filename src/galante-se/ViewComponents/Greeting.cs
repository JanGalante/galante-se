using galante_se.Services;
using Microsoft.AspNetCore.Mvc;

namespace galante_se.ViewComponents
{
    /// <summary>
    /// A ViewComponent can be viewed at as a controller without any routing to it
    /// </summary>
    public class Greeting : ViewComponent
    {
        private IGreeter _greeter;

        public Greeting(IGreeter greeter)
        {
            _greeter = greeter;
        }

        public IViewComponentResult Invoke()
        {
            var model = _greeter.GetGreeting();
            //Warning if the model is a string, MVC sees it as the view name. Therefor we need to specify "Default" view
            //By convention ViewComponent looks for views in the folder "Components" (place the folder in the shared folder or in an "controller" folder)
            return View("Default", model);
        }
    }
}
