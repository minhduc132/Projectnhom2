using Microsoft.AspNetCore.Mvc;

namespace aspdotnetcore2.Controllers

{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            ViewData["messgae"] = "Hello Duc";
            return View();
        }

        public string Welcome()
        {
            return "This is the welcome action method.... ";
        }
    }
}
