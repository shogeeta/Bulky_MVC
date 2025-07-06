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
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                //ModelState.AddModelError("Name", "The Display Order cannot exactly match the Name."); Name is key 
                ModelState.AddModelError("name", "The Display Order cannot exactly match the Name.");
                //string.Empty is used to add a model error that is not associated with any specific property
            }
            if (obj.Name != null && obj.Name.ToLower() == "test")
            {
                //ModelState.AddModelError("Name", "The Display Order cannot exactly match the Name."); key is empty so not display under any feild 
                ModelState.AddModelError("", "Test is an invalid value.");
                //string.Empty is used to add a model error that is not associated with any specific property
            }
            if (ModelState.IsValid)
            {
                //ModelState.IsValid checks if the model is valid based on data annotations
                //if not valid, it will return to the same view with validation errors
                _db.Categories.Add(obj);
                _db.SaveChanges();
                //To show notification add value to tempdata
                TempData["success"] = "Category created successfully";
                //return RedirectToAction("Index", "Category"); applies when it has to go to diff controller action method
                return RedirectToAction("Index");
            }    
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(id);//only on primary key
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);//try to find out whether the record exists or not
            //Category? categoryFromDb3 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();//used when you want to apply some conditions
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                //ModelState.IsValid checks if the model is valid based on data annotations
                //if not valid, it will return to the same view with validation errors
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                //return RedirectToAction("Index", "Category"); applies when it has to go to diff controller action method
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(id);//only on primary key
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);//try to find out whether the record exists or not
            //Category? categoryFromDb3 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();//used when you want to apply some conditions
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if (obj == null) { 
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
