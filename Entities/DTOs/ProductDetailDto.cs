using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProductDetailDto:IDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public Nullable<Double> Price { get; set; }
        public string CategoryName { get; set; }
    }
}
