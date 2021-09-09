﻿using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfEquipmentDal : EfEntityRepositoryBase<Equipment, SeaportContext>,IEquipmentDal
    {
    }
}
