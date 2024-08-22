using Bulkeyweb.Data;
using Bulkeyweb.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

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
            if (ModelState.IsValid)
            {
                _db.Categoris.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();


        }
        public IActionResult EditCategory(int ID)
        {
            if(ID == null|| ID==0)
            {
                return NotFound();
            }
            Category categoryformDb = _db.Categoris.Find(ID);
            if (categoryformDb == null)
            {
                return NotFound();
            }

            return View(categoryformDb);

        }
        [HttpPost]
        public IActionResult EditCategory(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categoris.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();


        }

        public IActionResult DeleteCategory(int? ID) // Changed int to int?
        {
            if (ID == null || ID == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _db.Categoris.Find(ID);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteCategoryPost(int ID)
        {
            var obj = _db.Categoris.Find(ID);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Categoris.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }

}
