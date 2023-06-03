using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        /*private readonly ApplicationDBContext _db;*/
        /*private readonly ICategoryRepository _db;*/
        private readonly IUnitOfWork _unitOfWork;

        /*public CategoryController(ApplicationDBContext db)*/
        /*public CategoryController(ICategoryRepository db)*/
        public CategoryController(IUnitOfWork unitOfWork)
        {
            /*_db = db;*/
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            /*IEnumerable<Category> objCategoryList = _db.Categories;*/
            /*IEnumerable<Category> objCategoryList = _db.GetAll();*/
            IEnumerable<Category> objCategoryList = _unitOfWork.Category.GetAll();
            return View(objCategoryList);
        }
        // Get
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "the Display Order should cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                /*_db.Categories.Add(obj);*/
                /*_db.Add(obj);*/
                _unitOfWork.Category.Add(obj);
                /*_db.SaveChanges();*/
                /*_db.Save();*/
                _unitOfWork.Save();
                TempData["success"] = "Category successfully created";
                return RedirectToAction("Index");
            }
            return View(obj);

        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFromDb = _db.Categories.Find(id);
            /*var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id == "id");*/
            /*var categoryFromDbFirst = _db.GetFirstOrDefault(u => u.Id == id);*/
            var categoryFromDbFirst = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
            /*if (categoryFromDb == null)*/
            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }
            /*return View(categoryFromDb);*/
            return View(categoryFromDbFirst);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "the Display Order should cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                /*_db.Categories.Update(obj);
                _db.SaveChanges();*/
                /*_db.Update(obj);
                _db.Save();*/
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category " + obj.Name + " successfully updated";
                return RedirectToAction("Index");
            }
            return View(obj);

        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            /*var categoryFromDb = _db.Categories.Find(id);*/
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id == id);
            /*var categoryFromDbFirst = _db.GetFirstOrDefault(u=>u.Id == id);*/
            var categoryFromDbFirst = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
            /*if (categoryFromDb == null)*/
            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }
            /*return View(categoryFromDb);*/
            return View(categoryFromDbFirst);
        }
        //POST
        /*[HttpPost]*/
        [HttpPost, ActionName("Delete")] // use DeletePost with Delete Action but Post Method
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            /*var obj  = _db.Categories.Find(id);*/
            /*var obj = _db.GetFirstOrDefault(u=>u.Id==id);*/
            var obj = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                /*_db.Categories.Remove(obj);
                _db.SaveChanges();*/
                /*_db.Remove(obj);
                _db.Save();*/
                _unitOfWork.Category.Remove(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category " + obj.Name + " successfully deleted";
                return RedirectToAction("Index");
            }
            return View(obj);

        }
    }
}
