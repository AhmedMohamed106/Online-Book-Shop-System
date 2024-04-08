using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BulkyWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfwork _unitOfwork;

        public HomeController(ILogger<HomeController> logger , IUnitOfwork unitOfwork)
        {
            _logger = logger;
            _unitOfwork = unitOfwork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> ProductList = _unitOfwork.ProductRepository.GetAll(includeProperties: "Category");

            return View(ProductList);
        }

        public IActionResult Details(int? id)
        {
            Product product = _unitOfwork.ProductRepository.Get(p => p.Id == id, includeProperties: "Category");

            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}