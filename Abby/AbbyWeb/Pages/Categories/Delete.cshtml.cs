using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace AbbyWeb.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        
        private readonly ApplicationDbContext _db;
        /*[BindProperty]*/
        public Category Category { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
                _db=db;
        }
        
        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);
            /*Category = _db.Category.First(u=>u.Id==id); // Will throw error if more than 1 is found
            Category = _db.Category.FirstOrDefault(u => u.Id == id);
            Category = _db.Category.Single(u=>u.Id==id); // Will throw error if more than 1 is found
            Category = _db.Category.Single(u=>u.Id == id);
            Category = _db.Category.Where(u => u.Id == id);*/
        }
        /*public async Task<IActionResult> OnPost(Category category)*/
        public async Task<IActionResult> OnPost()
        {

            var categoryFromDb = _db.Category.Find(Category.Id);
            if (categoryFromDb != null) {
                _db.Category.Remove(categoryFromDb);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category " + Category.Name +  " deleted successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
