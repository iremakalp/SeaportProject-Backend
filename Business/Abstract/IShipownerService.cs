using Core.Utilities.Result;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IShipownerService
    {
        IDataResult<List<Shipowner>> GetAll();
        IResult Add(Shipowner shipowner);
        IResult Update(Shipowner shipowner);
        IResult Delete(Shipowner shipowner);
    }
}
