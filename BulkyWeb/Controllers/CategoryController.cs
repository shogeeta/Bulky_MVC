using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(ModelState.IsValid)
            {
                //ModelState.IsValid checks if the model is valid based on data annotations
                //if not valid, it will return to the same view with validation errors
                _db.Categories.Add(obj);
                _db.SaveChanges();
                //return RedirectToAction("Index", "Category"); applies when it has to go to diff controller action method
                return RedirectToAction("Index");
            }    
            return View();
        }
    }
}
