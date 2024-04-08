using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BulkyWeb_razor.Data;
using BulkyWeb_razor.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb_razor.Pages.Categories
{
    public class CreateModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Category category { set; get; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;

        }

        public void OnGet()
        {
        }
        public IActionResult OnPost( )
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Categories.Add(category);
            _db.SaveChanges();

            TempData["success"] = "Category Created Successfully";

            return RedirectToPage("Index");
        }
    }
}
