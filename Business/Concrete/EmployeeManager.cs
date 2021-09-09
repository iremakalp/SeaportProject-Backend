using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }
        public IResult Add(Employee employee)
        {
            IResult result = BusinessRules.Run(CheckEmployeeCount(employee.AgentId),
                CheckIfEmployeeExists(employee.FirstName, employee.LastName));
            if (result != null)
            {
                return result;
            }
            _employeeDal.Add(employee);
            return new SuccessResult(Messages.EmployeAdded);
        }
        public IResult Delete(Employee employee)
        {
            _employeeDal.Delete(employee);
            return new SuccessResult();
        }
        public IDataResult<List<Employee>> GetAll()
        {
            return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll());
        }
        public IDataResult<List<Employee>> GetByAge(int age)
        {
            var result = _employeeDal.GetAll(e => e.Age == age);
            return new SuccessDataResult<List<Employee>>(result);
        }

        public IDataResult<List<Employee>> GetByShipownerId(int shipownerId)
        {
            var result = _employeeDal.GetAll(e => e.AgentId == shipownerId);
            return new SuccessDataResult<List<Employee>>(result);
        }

        public IDataResult<List<EmployeeDetailDto>> GetDetails()
        {
            return new SuccessDataResult<List<EmployeeDetailDto>>(_employeeDal.GetEmployeeDetails());
        }
        public IResult Update(Employee employee)
        {
            _employeeDal.Update(employee);
            return new SuccessResult();
        }
        private IResult CheckIfEmployeeExists(string firstName, string lastName)
        {
            var result = _employeeDal.GetAll(e => e.FirstName == firstName && e.LastName == lastName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CheckIfEmployeeExists);
            }
            return new SuccessResult();
        }
        private IResult CheckEmployeeCount(int shipownerId)
        {
            var result = _employeeDal.GetAll(e => e.AgentId == shipownerId).Count;
            if (result == 3)
            {
                return new ErrorResult(Messages.CheckEmployeeCount);
            }
            return new SuccessResult();
        }
    }
}
