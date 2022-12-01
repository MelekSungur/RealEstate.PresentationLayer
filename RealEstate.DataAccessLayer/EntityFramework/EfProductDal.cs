using Microsoft.EntityFrameworkCore;
using RealEstate.DataAccessLayer.Abstract;
using RealEstate.DataAccessLayer.Concrete;
using RealEstate.DataAccessLayer.Repositories;
using RealEstate.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public List<Product> GetProductByCategory()
        {
            using (var contex=new Context())
            {
              return  contex.Products.Include(x => x.Category).ToList();
            }
        }
    }
}
