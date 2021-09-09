using Core.Utilities.Result;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IEquipmentService
    {
        IDataResult<List<Equipment>> GetAll();
        IResult Add(Equipment equipment);
        IResult Update(Equipment equipment);
        IResult Delete(Equipment equipment);
        IDataResult<List<Equipment>> GetByQuentity(int quentity);
    }
}
