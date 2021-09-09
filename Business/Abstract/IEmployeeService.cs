using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        IDataResult<List<Employee>> GetAll();
        IResult Add(Employee employee);
        IResult Update(Employee employee);
        IResult Delete(Employee employee);
        IDataResult<List<EmployeeDetailDto>> GetDetails();
        IDataResult<List<Employee>> GetByShipownerId(int shipownerId);
        IDataResult<List<Employee>> GetByAge(int age);

    }
}
