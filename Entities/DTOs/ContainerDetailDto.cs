using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ContainerDetailDto: IDto
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public Nullable<Double> Capacity { get; set; }
        public Nullable<Double> CargoWeight { get; set; }
        public string ColorName { get; set; }
        public string PortName { get; set; }
    }
}
