using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;  
        public Category? Category { get; set; }
        public void OnGet(int? id)
        {
            Category = _db.Categories.Find(id);
        }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }   
        public IActionResult OnPost()
        {
            //if (id == null || id == 0)
            //{
            //    return NotFound();
            //}
            if(ModelState.IsValid)
            {
                _db.Categories.Remove(Category);
                _db.SaveChanges();
                TempData["success"] = "Category deleted successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }   
    }
}
