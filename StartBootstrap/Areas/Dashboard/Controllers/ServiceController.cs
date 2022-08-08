using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StartBootstrap.Data;
using StartBootstrap.Models;

namespace StartBootstrap.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class ServiceController : Controller
    {
        private readonly AppDbContext _context;
        public ServiceController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var services=_context.Services.ToList();
            return View(services);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Services services)
        {
            _context.Services.Add(services);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
            return View();
        }

        public IActionResult Edit(int id)
        {
            var services=_context.Services.FirstOrDefault(x=>x.Id==id);
            return View(services);
        }
        [HttpPost]
        public IActionResult Edit(int id,Services service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        
           
        }

        public IActionResult Delete(int id)
        {
            var services = _context.Services.FirstOrDefault(x=>x.Id == id);
            return View(services);
        }
        [HttpPost]
        public IActionResult Delete(int id,Services service)
        {
            _context.Services.Remove(service);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
