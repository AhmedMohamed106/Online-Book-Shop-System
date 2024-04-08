using BulkyWeb_razor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BulkyWeb_razor.Models;

namespace BulkyWeb_razor.Pages.Categories
{
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public List<Category> CategoryList { set; get; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }



        public void OnGet()
        {
            CategoryList = _db.Categories.ToList();
        }
    }
}
