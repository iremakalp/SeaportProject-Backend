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
    public class ShipownerManager : IShipownerService
    {
        IShipownerDal _shipownerDal;

        public ShipownerManager(IShipownerDal shipownerDal)
        {
            _shipownerDal = shipownerDal;
        }

        public IResult Add(Shipowner shipowner)
        {
            IResult result = BusinessRules.Run(CheckIfShipownerExists(shipowner.ShipownerName));
            if (result != null)
            {
                return result;
            }
            _shipownerDal.Add(shipowner);
            return new SuccessResult(Messages.ShipownerAdded);
        }

        public IResult Delete(Shipowner shipowner)
        {
            _shipownerDal.Delete(shipowner);
            return new SuccessResult();
        }

        public IDataResult<List<Shipowner>> GetAll()
        {
            return new SuccessDataResult<List<Shipowner>>(_shipownerDal.GetAll());
        }

        public IResult Update(Shipowner shipowner)
        {
            _shipownerDal.Update(shipowner);
            return new SuccessResult(Messages.ShipownerUpdated);
        }
        private IResult CheckIfShipownerExists(string shipownerName)
        {
            var result = _shipownerDal.GetAll(s => s.ShipownerName == shipownerName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CheckIfShipownerExists);
            }
            return new SuccessResult();
        }
    }
}
