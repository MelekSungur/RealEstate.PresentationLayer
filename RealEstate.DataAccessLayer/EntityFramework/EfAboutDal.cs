﻿using RealEstate.DataAccessLayer.Abstract;
using RealEstate.DataAccessLayer.Repositories;
using RealEstate.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.DataAccessLayer.EntityFramework
{
    public class EfAboutDal:GenericRepository<About>,IAboutDal
    {
    }
}
