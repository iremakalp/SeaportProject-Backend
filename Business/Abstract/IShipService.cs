using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IShipService
    {
        List<Ship> Get();
        IDataResult<List<Ship>> GetAll();
        IResult Add(Ship ship);
        IResult Update(Ship ship);
        IResult Delete(Ship ship);
        IDataResult<List<ShipDetailDto>> GetDetail();
        IDataResult<List<Ship>> GetByName(string shipName);
        IDataResult<List<Ship>> GetByTypeId(int typeId);
        IDataResult<List<Ship>> GetByFalg(string flag);
        IDataResult<List<Ship>> GetByPort(int portId);
        IDataResult<List<Ship>> GetByDock(int dockNumaber);
        IDataResult<List<Ship>> GetByImoNo(int imoNo);
        IDataResult<List<Ship>> GetByStatus(bool status);
        IDataResult<List<Ship>> GetByTonnage(float maxTonnage,float minTonnage);
        IDataResult<List<Ship>> GetByLeavingDate(DateTime leavingDate);
        IDataResult<List<Ship>> GetByDockingDate(DateTime dockingDate);
        IDataResult<List<Ship>> GetByBreadth(float maxBreadth,float minBreadth);
        IDataResult<List<Ship>> GetByLength(float maxLength, float minLength);
        IDataResult<List<Ship>> GetByShipowner(int shipownerId);
    }
}
