using Bulkeyweb.Data;
using Bulkeyweb.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulkeyweb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _db;
        public CategoryController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objcategories = _db.Categoris.ToList();
            return View(objcategories);
        }
        public IActionResult CreateCategory()
        {
            
            return View();

        }
        [HttpPost]
        public IActionResult CreateCategory(Category obj)
        {
            _db.Categoris.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
