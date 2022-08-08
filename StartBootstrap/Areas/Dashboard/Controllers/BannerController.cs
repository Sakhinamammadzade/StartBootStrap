using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StartBootstrap.Data;
using StartBootstrap.Models;

namespace StartBootstrap.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class BannerController : Controller
    {
        private readonly AppDbContext _context;

        public BannerController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var banner = _context.Banners.FirstOrDefault();
            return View(banner);
        }

        public IActionResult Create()
        {

            var banner = _context.Banners.FirstOrDefault();
            if (banner != null)
            {
                return RedirectToAction("index");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Create(Banner banner, IFormFile myPhoto)
        {
            string newPhoto = Guid.NewGuid().ToString() + Path.GetExtension(myPhoto.FileName);

            string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image", newPhoto);
            //string fileextation = Path.GetExtension(myPhoto.FileName);
            //if (fileExtation == ".jpg" || fileExtation == ".png")
            //{

            //    ViewData["Message"] = "only image format is accepted";
            //}
            //if (fileextation != ".jpg")
            //{
            //    ViewBag.PhotoError = "only image format is accepted";
            //    return View();
            //}
            using (var img = new FileStream(SavePath, FileMode.Create))
            {
                myPhoto.CopyTo(img);
            }

            banner.Url = "image/" + newPhoto;
            _context.Banners.Add(banner);
            _context.SaveChanges();
            return RedirectToAction("index");

        }

        public IActionResult Delete(int id)
        {

            var banner = _context.Banners.FirstOrDefault(x => x.Id == id);
            if (banner == null)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpPost]
        public IActionResult Delete(Banner banner)
        {
            if (banner == null)
            {
                return RedirectToAction("Index");
            }
            _context.Banners.Remove(banner);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    
        [HttpGet]
        public IActionResult Detail(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var banner=_context.Banners.FirstOrDefault(x => x.Id == id);

            if (banner == null)
            {
                return NotFound();
            }
            return View(banner);
        }



    }
 

}

