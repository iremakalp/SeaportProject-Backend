using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IOrderDetailService
    {
        IDataResult<List<OrderDetail>> GetAll();
        IResult Add(OrderDetail orderDetail);
        IResult Update(OrderDetail orderDetail);
        IResult Delete(OrderDetail orderDetail);
        IDataResult<List<OrderDetailDto>> GetDetails();
        IDataResult<List<OrderDetail>> GetByCustomer(int customerId);
        IDataResult<List<OrderDetail>> GetByProduct(int productId);
        IDataResult<List<OrderDetail>> GetByDate(DateTime dateTime);
    }
}
