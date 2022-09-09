using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IFeatureService
    {
        void Insert(Feature t);
        void Update(Feature t);
        void Delete(Feature t);
        List<Feature> GetListAll();
        Feature GetByID(int id);
    }
}
