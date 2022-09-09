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
    public class BrandManager: IBrandService
    {
        private IBrandRepository _brandRepository;
        public BrandManager(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public void Delete(Brand t)
        {
            _brandRepository.Delete(t);
        }

        public Brand GetByID(int id)
        {
            return _brandRepository.GetByID(id);
        }

        public Brand GetByName(string name)
        {
            return _brandRepository.GetByName(name);
        }

        public List<Brand> GetListAll()
        {
            return _brandRepository.GetListAll();
        }

        public void Insert(Brand t)
        {
            _brandRepository.Insert(t);
        }

        public void Update(Brand t)
        {
            _brandRepository.Update(t);
        }
    }
}
