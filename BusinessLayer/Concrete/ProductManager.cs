using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager:IProductService
    {
        private IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Delete(Product t)
        {
            _productRepository.Delete(t);
        }

        public Product GetByID(int id)
        {
            return _productRepository.GetByID(id);
        }

        public List<Product> GetListAll()
        {
            return _productRepository.GetListAll();
        }

        public List<Product> GetProductFeatures()
        {
            
           return _productRepository.GetProductFeatures();
        }

        public void Insert(Product t)
        {
            _productRepository.Insert(t);
        }

        public void Update(Product t)
        {
            _productRepository.Update(t);
        }
    }
}
