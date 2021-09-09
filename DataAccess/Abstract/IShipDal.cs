using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
namespace DataAccess.Abstract
{
    public interface IShipDal : IEntityRepository<Ship>
    {
        List<ShipDetailDto> GetShipDetails();
    }
}
