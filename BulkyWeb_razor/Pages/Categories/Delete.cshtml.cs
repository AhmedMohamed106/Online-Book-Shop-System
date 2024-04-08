using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BulkyWeb_razor.Models;
using BulkyWeb_razor.Data;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb_razor.Pages.Categories
{
    //[BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Category category { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult OnGet(int? id)
        {
            category = _db.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            _db.Categories.Remove(category);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";

            return RedirectToPage("Index");
        }
    }
}
