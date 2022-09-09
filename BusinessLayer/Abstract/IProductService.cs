using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductService
    {
        void Insert(Product t);
        void Update(Product t);
        void Delete(Product t);
        List<Product> GetListAll();
        Product GetByID(int id);
        List<Product> GetProductFeatures();
    }
}
