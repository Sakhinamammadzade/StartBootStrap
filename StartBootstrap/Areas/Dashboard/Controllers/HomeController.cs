using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StartBootstrap.Areas.Dashboard.Controllers
{
    [Area ("Dashboard")]
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
