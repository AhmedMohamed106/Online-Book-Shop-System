using Bulky.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Bulky.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bulky.Models.Models.ViewModels;
using System.IO;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfwork _Unitofwork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfwork unitofwork , IWebHostEnvironment webHostEnvironment)
        {
            _Unitofwork = unitofwork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Product> products = _Unitofwork.ProductRepository.GetAll(includeProperties: "Category").ToList();
            
            return View(products);
        }

        

        public IActionResult Upsert(int? id)
        {
            IEnumerable<SelectListItem> CategoryList = _Unitofwork.CategoryRepository
                .GetAll().Select(p => new SelectListItem
                {
                    Text = p.Name,
                    Value = p.Id.ToString()

                });
            
            ProductVM productVM = new()
            {
                CategoryList = CategoryList,
                product = new Product()
            };

            //Create section

            if (id == null || id == 0)
            {
                return View(productVM);
            }
            /// update Section
            else
            {
            

                productVM.product = _Unitofwork.ProductRepository.Get(p => p.Id == id);
                return View(productVM);
            }
        }
        [HttpPost]
        public IActionResult Upsert(ProductVM productVM , IFormFile? file)
        {
            

            if (ModelState.IsValid)

            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileNAme = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productpath = Path.Combine(wwwRootPath, @"Images\Product");

                    if(! (string.IsNullOrEmpty(productVM.product.ImgUrl)))
                    {
                        ///delete the old image
                        var oldImgPath = Path.Combine(wwwRootPath, productVM.product.ImgUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImgPath))
                        {
                            System.IO.File.Delete(oldImgPath);
                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(productpath, fileNAme), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    productVM.product.ImgUrl = @"\Images\Product\"+fileNAme;

                   
                }
                if (productVM.product.Id == 0)
                {
                    _Unitofwork.ProductRepository.Add(productVM.product);
                }
                else
                {
                    _Unitofwork.ProductRepository.Update(productVM.product);

                }
                _Unitofwork.Save();
                TempData["Success"] = "Product Created Successfully ";
                return RedirectToAction("Index");

            }

            else
            {
                IEnumerable<SelectListItem> CategoryList = _Unitofwork.CategoryRepository
               .GetAll().Select(p => new SelectListItem
               {
                   Text = p.Name,
                   Value = p.Id.ToString()

               });


                productVM.CategoryList = CategoryList;
                   

                return View(productVM);
            }
           
        }
        //public IActionResult Delete(int? id)
        //{
        //    if(id == 0 || id == null)
        //    {
        //        return NotFound();
        //    }

        //    Product? product = _Unitofwork.ProductRepository.Get(p => p.Id == id);

        //    if(product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product);

        //}

        //[HttpPost , ActionName("Delete")]
        //public IActionResult DeletePost(int? id)
        //{
        //    Product? product = _Unitofwork.ProductRepository.Get(p => p.Id == id);

        //    if (ModelState.IsValid)
        //    {
        //        _Unitofwork.ProductRepository.Remove(product);
        //        _Unitofwork.Save();
        //        TempData["success"] = "Product Deleted Successfully";
        //        return RedirectToAction("Index");
        //    }

        //    return RedirectToAction("Index");
        //}
        #region API calls

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> products = _Unitofwork.ProductRepository.GetAll(includeProperties: "Category").ToList();
            return Json((new { data = products }));
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var productToBeDeleted = _Unitofwork.ProductRepository.Get(u => u.Id == id);
            if (productToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            string productPath = @"Images\Product"+id;
            string finalPath = Path.Combine(_webHostEnvironment.WebRootPath, productPath);

            if (Directory.Exists(finalPath))
            {
                string[] filePaths = Directory.GetFiles(finalPath);
                foreach (string filePath in filePaths)
                {
                    System.IO.File.Delete(filePath);
                }

                Directory.Delete(finalPath);
            }


            _Unitofwork.ProductRepository.Remove(productToBeDeleted);
            _Unitofwork.Save();

            return Json(new { success = true, message = "Deleted Successfully" });
        }


        #endregion
    }
}
