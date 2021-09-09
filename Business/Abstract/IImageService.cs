using Core.Utilities.Result;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IImageService
    {
        IResult Add(Image image);
        IResult Update(Image image);
        IResult Delete(Image image);
        IDataResult<List<Image>> GetByShipId(int shipId);
    }
}
