using Core.Utilities.Result;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IPortService
    {
        IDataResult<List<Port>> GetAll();
        IResult Update(Port port);
    }
}
