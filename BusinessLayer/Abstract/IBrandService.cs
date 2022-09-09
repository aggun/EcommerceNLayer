using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBrandService
    {
        void Insert(Brand t);
        void Update(Brand t);
        void Delete(Brand t);
        List<Brand> GetListAll();
        Brand GetByID(int id);
        Brand GetByName(string name);
    }
}
