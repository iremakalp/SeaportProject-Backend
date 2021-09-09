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
    public class ShipTypeManager : IShipTypeService
    {
        IShipTypeDal _shipTypeDal;

        public ShipTypeManager(IShipTypeDal shipTypeDal)
        {
            _shipTypeDal = shipTypeDal;
        }

        public IResult Add(ShipType shipType)
        {
            IResult result = BusinessRules.Run(CheckIfTypeExists(shipType.TypeName));
            if (result != null)
            {
                return result;
            }
            _shipTypeDal.Add(shipType);
            return new SuccessResult();
        }

        public IResult Delete(ShipType shipType)
        {
            _shipTypeDal.Delete(shipType);
            return new SuccessResult();
        }

        public IDataResult<List<ShipType>> GetAll()
        {
            return new SuccessDataResult<List<ShipType>>(_shipTypeDal.GetAll());
        }

        public IDataResult<List<ShipType>> GetById(int id)
        {
            var result = _shipTypeDal.GetAll(s => s.Id == id);
            return new SuccessDataResult<List<ShipType>>(result);
        }

        public IResult Update(ShipType shipType)
        {
            _shipTypeDal.Update(shipType);
            return new SuccessResult();
        }
        private IResult CheckIfTypeExists(string typeName)
        {
            var result = _shipTypeDal.GetAll(s => s.TypeName == typeName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CheckIfTypeExists);
            }
            return new SuccessResult();
        }
    }
}
