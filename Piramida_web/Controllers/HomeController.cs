using Microsoft.AspNetCore.Mvc;

namespace Piramida_web.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        [HttpGet, Route(""), Route("Index")]
        public ActionResult Index()
        {
            return PhysicalFile(Path.Combine("C:/Users/User/Desktop/FPyramid1", "index.html"), "text/html");
        }
    }
}
