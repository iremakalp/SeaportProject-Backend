using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class OrderDetailManager : IOrderDetailService
    {
        IOrderDetailDal _orderDetailDal;
        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }
        public IResult Add(OrderDetail orderDetail)
        {
            IResult result = BusinessRules.Run(CheckOrderCustomerCount(orderDetail.CustomerId, orderDetail.OrderDate),
                CheckOrderCustomerProductCount(orderDetail.CustomerId, orderDetail.ProductId, orderDetail.OrderDate));
            if (result != null)
            {
                return result;
            }
            _orderDetailDal.Add(orderDetail);
            return new SuccessResult(Messages.OrderDetailAdded);
        }
        public IResult Delete(OrderDetail orderDetail)
        {
            _orderDetailDal.Delete(orderDetail);
            return new SuccessResult();
        }
        public IDataResult<List<OrderDetail>> GetAll()
        {
            return new SuccessDataResult<List<OrderDetail>>
                (_orderDetailDal.GetAll());
        }

        public IDataResult<List<OrderDetail>> GetByCustomer(int customerId)
        {
            var result = _orderDetailDal.GetAll(o => o.CustomerId == customerId);
            return new SuccessDataResult<List<OrderDetail>>(result);
        }

        public IDataResult<List<OrderDetail>> GetByDate(DateTime dateTime)
        {
            var result = _orderDetailDal.GetAll(o => o.OrderDate == dateTime);
            return new SuccessDataResult<List<OrderDetail>>(result);
        }

        public IDataResult<List<OrderDetail>> GetByProduct(int productId)
        {
            var result = _orderDetailDal.GetAll(o => o.ProductId == productId);
            return new SuccessDataResult<List<OrderDetail>>(result);
        }

        public IDataResult<List<OrderDetailDto>> GetDetails()
        {
            return new SuccessDataResult<List<OrderDetailDto>>(_orderDetailDal.GetOrderDetail());
        }

        public IResult Update(OrderDetail orderDetail)
        {
            IResult result = BusinessRules.Run(CheckOrderCustomerCount(orderDetail.CustomerId, orderDetail.OrderDate),
                   CheckOrderCustomerProductCount(orderDetail.CustomerId, orderDetail.ProductId, orderDetail.OrderDate));
            if (result != null)
            {
                return result;
            }
            _orderDetailDal.Update(orderDetail);
            return new SuccessResult(Messages.OrderDetailUpdated);
        }
        private IResult CheckOrderCustomerCount(int customerId, DateTime orderDate)
        {
            var result = _orderDetailDal.GetAll(o => o.CustomerId == customerId &&
            o.OrderDate == orderDate).Count;
            if (result == 3)
            {
                return new ErrorResult(Messages.CheckOrderCustomerCount);
            }
            return new SuccessResult();
        }
        private IResult CheckOrderCustomerProductCount(int customerId, int productId, DateTime orderDate)
        {
            var result = _orderDetailDal.GetAll(o => o.CustomerId == customerId && o.OrderDate == orderDate
              && o.ProductId == productId).Count;
            if (result == 1)
            {
                return new ErrorResult(Messages.CheckOrderCustomerProductCount);
            }
            return new SuccessResult();
        }
    }
}
