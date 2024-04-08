using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BulkyWeb_razor.Data;
using BulkyWeb_razor.Models;
using Microsoft.EntityFrameworkCore;


namespace BulkyWeb_razor.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Category category { get; set; }
        public EditModel(ApplicationDbContext db)
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Categories.Update(category);
            _db.SaveChanges();
            TempData["success"] = "Category Updated Successfully";

            return RedirectToPage("Index");
        }
    }
}
