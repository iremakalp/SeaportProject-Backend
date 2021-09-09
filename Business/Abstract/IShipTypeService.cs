using Core.Utilities.Result;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IShipTypeService
    {
        IDataResult<List<ShipType>> GetAll();
        IResult Add(ShipType shipType);
        IResult Update(ShipType shipType);
        IResult Delete(ShipType shipType);
        IDataResult<List<ShipType>> GetById(int id);
    }
}
