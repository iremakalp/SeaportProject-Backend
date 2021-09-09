using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class PortManager : IPortService
    {
        IPortDal _portDal;

        public IDataResult<List<Port>> GetAll()
        {
            return new SuccessDataResult<List<Port>>(_portDal.GetAll());
        }

        public IResult Update(Port port)
        {
            _portDal.Update(port);
            return new SuccessResult();
        }
    }
}
