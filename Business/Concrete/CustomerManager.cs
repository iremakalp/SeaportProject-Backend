using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            IResult result = BusinessRules.Run(CheckIfCustomerExists(customer.FirstName, customer.LastName));
            if (result != null)
            {
                return result;
            }
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult();
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<List<Customer>> GetByCountry(string country)
        {
            var result = _customerDal.GetAll(c => c.Country == country);
            return new SuccessDataResult<List<Customer>>(result);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
        private IResult CheckIfCustomerExists(string firtName, string lastName)
        {
            var result = _customerDal.GetAll(c => c.FirstName == firtName && c.LastName == lastName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CheckCustomerExists);
            }
            return new SuccessResult();
        }
    }
}
