using Task1.Models;

namespace Task1.Repos
{
    public interface IRepo<T>
        where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T item);
        void Update(T item);
        void Delete(int id);
        int SaveChanges();

    }
}
