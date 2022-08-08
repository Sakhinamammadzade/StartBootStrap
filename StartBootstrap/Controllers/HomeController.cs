using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var portfolio=_context.Portfolio.Include(x=>x.Category).ToList();
            var Contact =_context.Contacts.FirstOrDefault();
            
       

            HomeView view = new()
            {
                Services = services,
                Banner = banner,
                Portfolios=portfolio,
                Contact=Contact
                
               
            };

            return View(view);
        }

       public async Task< IActionResult> Contact(Contact contact)
        {
            _context.Contacts.Add(contact);
           await  _context.SaveChangesAsync();
            return this.Ok();

        }
    }
}
