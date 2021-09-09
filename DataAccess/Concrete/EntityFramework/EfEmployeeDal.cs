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
    public class EfEmployeeDal : EfEntityRepositoryBase<Employee, SeaportContext>, 
        IEmployeeDal
    {
        public List<EmployeeDetailDto> GetEmployeeDetails()
        {
            using (SeaportContext context = new SeaportContext())
            {
                var result = from e in context.Employees
                             join s in context.Shipowners
                             on e.AgentId equals s.Id
                             select new EmployeeDetailDto
                             {
                                 Id = e.Id,
                                 FirstName = e.FirstName,
                                 LastName = e.LastName,
                                 Age = e.Age,
                                 Email = e.Email,
                                 Phone = e.Phone,
                                 ShipownerName = s.ShipownerName,
                                 ShipownerPhone = s.Phone
                             };
                return result.ToList();
                               
            }
        }
    }
}
