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
    public class EfOrderDetailDal : EfEntityRepositoryBase<OrderDetail, SeaportContext>,
        IOrderDetailDal
    {
        public List<OrderDetailDto> GetOrderDetail()
        {
            using (SeaportContext context = new SeaportContext())
            {
                var result = from o in context.OrderDetails
                             join c in context.Customers
                             on o.CustomerId equals c.Id
                             join p in context.Products
                             on o.ProductId equals p.Id
                             select new OrderDetailDto
                             {
                                 Id = o.Id,
                                 CustomerFirstName = c.FirstName,
                                 CustomerLastName = c.LastName,
                                 ProductName = p.ProductName,
                                 Quantity = o.Quantity,
                                 OrderDate = o.OrderDate
                             };
                return result.ToList();
            }
        }
    }
}
