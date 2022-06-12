using Microsoft.AspNetCore.Mvc;
using StartBootstrap.Data;
using StartBootstrap.Models;
using StartBootstrap.VievModel;

namespace StartBootstrap.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }


        Banner banner = new()
        {
            Id = 1,
            Url = "https://startbootstrap.github.io/startbootstrap-creative/assets/img/bg-masthead.jpg",
            Title = "Your Favorite Place for Free Bootstrap Themes",
            SubTitle = "Start Bootstrap can help you build better websites using the Bootstrap framework! Just download a theme and start customizing, no strings attached!"

        };

        public IActionResult Index()
        {
            var banner = _context.Banners.FirstOrDefault();
            var services = _context.Services.ToList();
            var portfolio=_context.Portfolio.ToList();
       

            HomeView view = new()
            {
                Services = services,
                Banner = banner,
                Portfolios=portfolio
               
            };

            return View(view);
        }

    
    }
}
