using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ShipDetailDto: IDto
    {
        public int Id { get; set; }
        public string ShipName { get; set; }
        public string ShipType { get; set; }
        public int ImoNo { get; set; }
        public string Flag { get; set; }
        public string Record { get; set; }
        public string ShipownerName { get; set; }
        public Nullable<Double> Breadth { get; set; }
        public Nullable<Double> Length { get; set; }
    }
}
