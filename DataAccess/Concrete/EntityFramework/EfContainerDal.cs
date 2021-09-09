using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfContainerDal : EfEntityRepositoryBase<Container, SeaportContext>, 
        IContainerDal
    {
        public List<ContainerDetailDto> GetContainerDetail()
        {
            using (SeaportContext context= new SeaportContext())
            {
                var result = from c in context.Containers
                             join color in context.Colors
                             on c.ColorId equals color.Id
                             join p in context.Ports
                             on c.PortId equals p.Id
                             select new ContainerDetailDto
                             {
                                 Id = c.Id,
                                 TypeName = c.TypeName,
                                 PortName = p.PortName,
                                 Capacity = c.Capacity,
                                 CargoWeight = c.CargoWeight,
                                 ColorName = color.ColorName
                             };
                return result.ToList();
            }
        }
    }
}
