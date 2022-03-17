using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Validation;

namespace Business.Concrete
{
    public class ContainerManager : IContainerService
    {
        IContainerDal _containerDal;
        public ContainerManager(IContainerDal containerDal)
        {
            _containerDal = containerDal;
        }
        [ValidationAspect(typeof(ContainerValidator))]
        public IResult Add(Container container)
        {
            IResult result = BusinessRules.Run(CheckIfTypeExist(container.TypeName));
            if (result != null)
            {
                return result;
            }
            _containerDal.Add(container);
            return new SuccessResult(Messages.ContainerAdded);
        }
        public IResult Delete(Container container)
        {
            _containerDal.Delete(container);
            return new SuccessResult();
        }
        public IDataResult<List<Container>> GetAll()
        {
            return new SuccessDataResult<List<Container>>(_containerDal.GetAll());
        }
        public IDataResult<List<Container>> GetByCapacity(float maxCapacity, float minCapacity)
        {
            var result = _containerDal.GetAll(c => c.Capacity <= maxCapacity && c.Capacity >= minCapacity);
            return new SuccessDataResult<List<Container>>(result);
        }
        public IDataResult<List<Container>> GetByCargoweight(float maxCargoweight, float minCargowweight)
        {
            var result = _containerDal.GetAll(c => c.CargoWeight <= maxCargoweight && c.CargoWeight >= minCargowweight);
            return new SuccessDataResult<List<Container>>(result);
        }
        public IDataResult<List<Container>> GetByHeight(float maxHeight, float minHeight)
        {
            var result = _containerDal.GetAll(c => c.Height <= maxHeight && c.Height >= minHeight);
            return new SuccessDataResult<List<Container>>(result);
        }
        public IDataResult<List<Container>> GetByLength(float maxLength, float minLength)
        {
            var result = _containerDal.GetAll(c => c.Length <= maxLength && c.Length >= minLength);
            return new SuccessDataResult<List<Container>>(result);
        }

        public IDataResult<List<Container>> GetByTypeName(string typeName)
        {
            var result = _containerDal.GetAll(c => c.TypeName == typeName);
            return new SuccessDataResult<List<Container>>(result);
        }

        public IDataResult<List<ContainerDetailDto>> GetContainerDetail()
        {
            return new SuccessDataResult<List<ContainerDetailDto>>(_containerDal.GetContainerDetail());
        }

        [ValidationAspect(typeof(ContainerValidator))]
        public IResult Update(Container container)
        {
          
            _containerDal.Update(container);
            return new SuccessResult(Messages.ContainerUpdated);
        }
        private IResult CheckIfTypeExist(string typeName)
        {
            var result = _containerDal.GetAll(c => c.TypeName == typeName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CheckContainerName);
            }
            return new SuccessResult();
        }
        
    }
}
