using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IContainerService
    {
        IDataResult<List<Container>> GetAll();
        IDataResult<List<ContainerDetailDto>> GetContainerDetail();
        IResult Add(Container container);
        IResult Update(Container container);
        IResult Delete(Container container);
        IDataResult<List<Container>> GetByTypeName(string typeName);
        IDataResult<List<Container>> GetByCapacity(float maxCapacity,float minCapacity);
        IDataResult<List<Container>> GetByCargoweight(float maxCargoweight,float minCargowweight);
        IDataResult<List<Container>> GetByLength(float maxLength,float minLength);     
        IDataResult<List<Container>> GetByHeight(float maxHeight,float minHeight);

    }
}
