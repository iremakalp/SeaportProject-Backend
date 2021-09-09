using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfShipDal : EfEntityRepositoryBase<Ship, SeaportContext>, 
        IShipDal
    {
        public List<ShipDetailDto> GetShipDetails()
        {
            using (SeaportContext context = new SeaportContext())
            {
                var result = from s in context.Ships
                             join t in context.ShipTypes
                             on s.ShipTypeId equals t.Id
                             join o in context.Shipowners
                             on s.ShipownerId equals o.Id
                             select new ShipDetailDto
                             {
                                 Id = s.Id,
                                 ShipName = s.ShipName,
                                 ShipType = t.TypeName,
                                 ImoNo = s.ImoNo,
                                 Flag = s.Flag,
                                 Record = s.Record,
                                 ShipownerName = o.ShipownerName,
                                 Breadth=s.Breadth,
                                 Length=s.Length
                             };
                return result.ToList();
            }
        }
    }
}
