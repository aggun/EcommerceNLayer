using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfBrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public Brand GetByName(string name)
        {
            using (var c = new Context())
            {
                return c.Brands.FirstOrDefault(b => b.Name == name);
            }
        }
    }
}
