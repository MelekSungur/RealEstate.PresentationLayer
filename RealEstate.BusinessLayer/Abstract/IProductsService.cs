﻿using RealEstate.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.BusinessLayer.Abstract
{
    public interface IProductsService:IGenericService<Product>
    {
        List<Product> TGetProductByCategory();
    }
}