using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace AbbyWeb.Pages.Categories
{
    [BindProperties]
    public class EditeModel : PageModel
    {
        
        private readonly ApplicationDbContext _db;
        /*[BindProperty]*/
        public Category Category { get; set; }
        public EditeModel(ApplicationDbContext db)
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
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                /*ModelState.AddModelError(string.Empty, "Display Order can not be the same as Name");*/
                ModelState.AddModelError("Category.Name", "Display Order can not be the same as Name");
            }
            if (ModelState.IsValid)
            {
                /*await _db.Category.AddAsync(category);*/
                _db.Category.Update(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category " + Category.Name + " updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
