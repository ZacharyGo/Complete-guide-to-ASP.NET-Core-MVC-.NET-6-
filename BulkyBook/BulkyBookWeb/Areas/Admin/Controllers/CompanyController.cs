using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Linq;

namespace BulkyBookWeb.Controllers;
[Area("Admin")]
public class CompanyController : Controller
{

    private readonly IUnitOfWork _unitOfWork;
    public CompanyController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IActionResult Index()
    {
        return View();
    }

       
    public IActionResult Upsert(int? id)
    {
        Company company = new();            

        if (id == null || id == 0) //Create Company
        {
            return View(company); 
        }
        else // Update Company
        {
            company  = _unitOfWork.Company.GetFirstOrDefault(u => u.Id == id);
            return View(company);
        }


    }
    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(Company obj, IFormFile? file)
    {
        if (ModelState.IsValid)
        {
            if (obj.Id == 0) {
                _unitOfWork.Company.Add(obj);
                TempData["success"] = "Company " + obj.Name + " successfully created";
            }
            else
            {
                _unitOfWork.Company.Update(obj);
                TempData["success"] = "Company " + obj.Name + " successfully updated";
            }
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        return View(obj);

    }
        
    #region API Calls
    [HttpGet]
    public IActionResult GetAll()
    {
        var companyList = _unitOfWork.Company.GetAll();
        return Json(new { data = companyList });
    }

    [HttpDelete] 
    public IActionResult Delete(int? id)
    {
        var obj = _unitOfWork.Company.GetFirstOrDefault(u => u.Id == id);
        if (obj == null)
        {
            return Json(new {success= false, message="Error while deleting"});
        }
        

        _unitOfWork.Company.Remove(obj);
        _unitOfWork.Save();
        TempData["success"] = "Company " + obj.Name + " successfully deleted";
        return Json(new { success = true, message = obj.Name + " successfully deleted"});
    }
    #endregion

}
