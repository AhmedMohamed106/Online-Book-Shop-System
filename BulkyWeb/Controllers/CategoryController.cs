using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            List<Category> CateoryList = _db.Categories.ToList();
            return View(CateoryList);
        }
       // [HttpPost]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name" , "the display order can't match the Name");
            }
            //if (category.Name != null && category.Name.ToLower() == "test")
            //{
            //    ModelState.AddModelError("", "test is an invalid value");
            //}
            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                TempData["success"] = "Category Created Successfully";

                return RedirectToAction("Index");
            }
            return View();
           
        }


        // GET: User/Edit/{id}
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            /* All are the same bot find is used ony for id or primary key*/
            Category?   category = _db.Categories.Find(id);
            //Category? category = _db.Categories.FirstOrDefault(p => p.Id == id);
            //Category? category = _db.Categories.Where(p => p.Id == id).FirstOrDefault();

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: User/Edit/{id}
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit( Category obj)
        {
            
            if (ModelState.IsValid)
            {
                
                _db.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Updated Successfully";

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: User/Delete/{id}
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            /* All are the same bot find is used ony for id or primary key*/
            Category? category = _db.Categories.Find(id);
            //Category? category = _db.Categories.FirstOrDefault(p => p.Id == id);
            //Category? category = _db.Categories.Where(p => p.Id == id).FirstOrDefault();
            return View(category);
            //return RedirectToAction("Index");
        }

        // POST: User/Delete/{id}
        [HttpPost , ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            Category? category = _db.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {

                _db.Remove(category);
                _db.SaveChanges();
                TempData["success"] = "Category Deleted Successfully";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
   
}

