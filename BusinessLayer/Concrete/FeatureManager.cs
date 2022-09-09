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
    public class FeatureManager: IFeatureService
    {
        private IFeatureRepository _featureRepository;
        public FeatureManager(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public void Delete(Feature t)
        {
            _featureRepository.Delete(t);
        }

        public Feature GetByID(int id)
        {
            return _featureRepository.GetByID(id);
        }

        public List<Feature> GetListAll()
        {
            return _featureRepository.GetListAll();
        }

        public void Insert(Feature t)
        {
            _featureRepository.Insert(t);
        }

        public void Update(Feature t)
        {
            _featureRepository.Update(t);
        }
    }
}
