using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CategoryManager: ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Delete(Category t)
        {
            // iş kuralları uygula burda
            _categoryRepository.Delete(t);
        }

        public Category GetByID(int id)
        {
            return _categoryRepository.GetByID(id);
        }

        public List<Category> GetListAll()
        {
            return _categoryRepository.GetListAll();
        }

        public void Insert(Category t)
        {
            // iş kuralları uygula burda
            _categoryRepository.Insert(t);
        }

        public void Update(Category t)
        {
            _categoryRepository.Update(t);
        }
    }
}
