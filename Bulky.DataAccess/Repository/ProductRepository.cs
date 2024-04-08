using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Product product)
        {
           //_dbContext.Products.Update(product);
           var objfromdb = _dbContext.Products.FirstOrDefault(p=>p.Id == product.Id);
            if (objfromdb != null) 
            { 
                objfromdb.Title= product.Title;
                objfromdb.Description= product.Description;
                objfromdb.ISBN = product.ISBN;
                objfromdb.Price = product.Price;
                objfromdb.Price50 = product.Price50;
                objfromdb.Price100 = product.Price100;
                objfromdb.ListPrice = product.ListPrice;
                objfromdb.Author = product.Author;
                objfromdb.CategoryId= product.CategoryId;
                if(objfromdb.ImgUrl != null)
                {
                    objfromdb.ImgUrl = product.ImgUrl;
                }


            }
        }
    }
}
