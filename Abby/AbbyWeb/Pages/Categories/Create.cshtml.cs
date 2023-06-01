using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        
        private readonly ApplicationDbContext _db;
        /*[BindProperty]*/
        public Category Category { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
                _db=db;
        }
        
        public void OnGet()
        {
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
                await _db.Category.AddAsync(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category " + Category.Name + " created successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
