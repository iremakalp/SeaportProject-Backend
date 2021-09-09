using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        IImageDal _imageDal;
        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }
        public IResult Add(Image image)
        {
            IResult result = BusinessRules.Run(CheckImageCount(image.ShipId));
            if (result != null)
            {
                return result;
            }
            _imageDal.Add(image);
            return new SuccessResult(Messages.ImageAdded);
        }
        public IResult Delete(Image image)
        {
            _imageDal.Delete(image);
            return new SuccessResult();
        }
        public IDataResult<List<Image>> GetByShipId(int shipId)
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll(i => i.ShipId == shipId));
        }
        public IResult Update(Image image)
        {
            _imageDal.Update(image);
            return new SuccessResult();
        }
        private IResult CheckImageCount(int shipId)
        {
            var result = _imageDal.GetAll(i => i.ShipId == shipId).Count;
            if (result == 5)
            {
                return new ErrorResult(Messages.CheckImageCount);
            }
            return new SuccessResult();
        }
    }
}
