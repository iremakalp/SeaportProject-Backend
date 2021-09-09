using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Entities.DTOs;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, SeaportContext>,
        IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (SeaportContext context = new SeaportContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.Id
                             select new ProductDetailDto
                             {
                                 Id = p.Id,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 Price = p.Price
                             };
                return result.ToList();
                   

            }
        }
    }
}
