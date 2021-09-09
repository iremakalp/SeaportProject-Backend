using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class ShipManager : IShipService
    {
        IShipDal _shipDal;
        public ShipManager(IShipDal shipDal)
        {
            _shipDal = shipDal;
        }

        public IResult Add(Ship ship)
        {
            IResult result = BusinessRules.Run(CheckDockCount(ship.DockNumber),
                CheckIfImoExists(ship.ImoNo), CheckShipTypeCount(ship.ShipTypeId),
                CheckIfShipnameExists(ship.ShipName));
            if (result != null)
            {
                return result;
            }
            _shipDal.Add(ship);
            return new SuccessResult(Messages.ShipAdded);
        }

        public IResult Delete(Ship ship)
        {
            _shipDal.Delete(ship);
            return new SuccessResult();
        }

        public List<Ship> Get()
        {
            var result = _shipDal.GetAll();
            return result;
        }

        public IDataResult<List<Ship>> GetAll()
        {
            return new SuccessDataResult<List<Ship>>(_shipDal.GetAll());
        }

        public IDataResult<List<Ship>> GetByBreadth(float maxBreadth, float minBreadth)
        {
            var result = _shipDal.GetAll(s => s.Breadth >= minBreadth && s.Breadth <= maxBreadth);
            return new SuccessDataResult<List<Ship>>(result);
        }
        public IDataResult<List<Ship>> GetByDock(int dockNumaber)
        {
            var result = _shipDal.GetAll(s => s.DockNumber == dockNumaber);
            return new SuccessDataResult<List<Ship>>(result);
        }
        public IDataResult<List<Ship>> GetByDockingDate(DateTime dockingDate)
        {
            var result = _shipDal.GetAll(s => s.DockingDate == dockingDate);
            return new SuccessDataResult<List<Ship>>(result);
        }
        public IDataResult<List<Ship>> GetByFalg(string flag)
        {
            //
            var result = _shipDal.GetAll(s => s.Flag == flag);
            return new SuccessDataResult<List<Ship>>(result);
        }
        public IDataResult<List<Ship>> GetByImoNo(int imoNo)
        {
            var result = _shipDal.GetAll(s => s.ImoNo == imoNo);
            return new SuccessDataResult<List<Ship>>(result);
        }
        public IDataResult<List<Ship>> GetByLeavingDate(DateTime leavingDate)
        {
            var result = _shipDal.GetAll(s => s.LeavingDate == leavingDate);
            return new SuccessDataResult<List<Ship>>(result);
        }
        public IDataResult<List<Ship>> GetByLength(float maxLength, float minLength)
        {
            var result = _shipDal.GetAll(s => s.Length >= minLength && s.Length <= maxLength);
            return new SuccessDataResult<List<Ship>>(result);
        }
        public IDataResult<List<Ship>> GetByName(string shipName)
        {
            var result = _shipDal.GetAll(s => s.ShipName == shipName);
            return new SuccessDataResult<List<Ship>>(result);
        }
        public IDataResult<List<Ship>> GetByPort(int portId)
        {
            var result = _shipDal.GetAll(s => s.PortId == portId);
            return new SuccessDataResult<List<Ship>>(result);
        }
        public IDataResult<List<Ship>> GetByShipowner(int shipownerId)
        {
            var result = _shipDal.GetAll(s => s.ShipownerId == shipownerId);
            return new SuccessDataResult<List<Ship>>(result);
        }
        public IDataResult<List<Ship>> GetByStatus(bool status)
        {
            var result = _shipDal.GetAll(s => s.Status == status);
            return new SuccessDataResult<List<Ship>>(result);
        }
        public IDataResult<List<Ship>> GetByTonnage(float maxTonnage, float minTonnage)
        {
            var result = _shipDal.GetAll(s => s.DTW >= minTonnage && s.DTW <= maxTonnage);
            return new SuccessDataResult<List<Ship>>(result);
        }
        public IDataResult<List<Ship>> GetByTypeId(int typeId)
        {
            var result = _shipDal.GetAll(s => s.ShipTypeId == typeId);
            return new SuccessDataResult<List<Ship>>(result);
        }
        public IDataResult<List<ShipDetailDto>> GetDetail()
        {
            return new SuccessDataResult<List<ShipDetailDto>>(_shipDal.GetShipDetails());
        }
        public IResult Update(Ship ship)
        {
            _shipDal.Update(ship);
            return new SuccessResult(Messages.ShipUpdated);
        }
        private IResult CheckIfShipnameExists(string shipName)
        {
            var result = _shipDal.GetAll(s => s.ShipName == shipName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CheckIfShipnameExists);
            }
            return new SuccessResult();
        }
        private IResult CheckIfImoExists(int imoNo)
        {
            var result = _shipDal.GetAll(s => s.ImoNo == imoNo).Any();
            if (result)
            {
                return new ErrorResult(Messages.CheckIfImoExists);
            }
            return new SuccessResult();
        }
        private IResult CheckDockCount(int dockNumber)
        {
            var result = _shipDal.GetAll(s => s.DockNumber == dockNumber).Count;
            if (result == 5)
            {
                return new ErrorResult(Messages.CheckDockCount);
            }
            return new SuccessResult();
        }
        private IResult CheckShipTypeCount(int typeId)
        {
            var result = _shipDal.GetAll(s => s.ShipTypeId == typeId).Count;
            if (result == 10)
            {
                return new ErrorResult(Messages.CheckShipTypeCount);
            }
            return new SuccessResult();
        }
    }
}
