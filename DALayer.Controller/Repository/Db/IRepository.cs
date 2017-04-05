using System.Collections.Generic;

namespace IStor.DAL.Repository.Db
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetList();
        int Count { get; }
        T FindById(int id);
        bool Insert(T item);
        bool Update(T item, int id);
        bool Delete(int id);
    }
}
