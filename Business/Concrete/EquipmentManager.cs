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
    public class EquipmentManager : IEquipmentService
    {
        IEquipmentDal _equipmentDal;

        public EquipmentManager(IEquipmentDal equipmentDal)
        {
            _equipmentDal = equipmentDal;
        }

        public IResult Add(Equipment equipment)
        {
            IResult result = BusinessRules.Run(CheckIfEquipmentExists(equipment.EquipmentName));
            if (result != null)
            {
                return result;
            }
            _equipmentDal.Add(equipment);
            return new SuccessResult(Messages.EquipmentAdded);
        }

        public IResult Delete(Equipment equipment)
        {
            _equipmentDal.Delete(equipment);
            return new SuccessResult();
        }

        public IDataResult<List<Equipment>> GetAll()
        {
            return new SuccessDataResult<List<Equipment>>(_equipmentDal.GetAll());
        }

        public IDataResult<List<Equipment>> GetByQuentity(int quentity)
        {
            var result = _equipmentDal.GetAll(e => e.Quantity == quentity);
            return new SuccessDataResult<List<Equipment>>(result);
        }

        public IResult Update(Equipment equipment)
        {
            _equipmentDal.Update(equipment);
            return new SuccessResult(Messages.EquipmentUpdated);
        }
        private IResult CheckIfEquipmentExists(string equipmentName)
        {
            var result = _equipmentDal.GetAll(e => e.EquipmentName == equipmentName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CheckEquipmentExists);
            }
            return new SuccessResult();
        }
    }
}
