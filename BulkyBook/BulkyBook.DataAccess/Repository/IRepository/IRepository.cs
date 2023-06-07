using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        // T - Category
        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null);  // Cause CategoryController 50 uses Add "var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id == id);"
        IEnumerable<T> GetAll(string? includeProperties = null); // Cause CategoryController 18 uses IEnumerable "IEnumerable<Category> objCategoryList = _db.Categories;"
        void Add(T entity);      // Cause CategoryController 36 uses Add " _db.Categories.Add(obj);"
        void Remove(T entity);      // Cause CategoryController 106 uses Remove "_db.Categories.Remove(obj);"
        void RemoveRange(IEnumerable<T> entity);
        

    }
}