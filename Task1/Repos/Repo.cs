
using Task1.Models;

namespace Task1.Repos
{
    public class Repo<T> : IRepo<T>
        where T : class
    {
        private readonly CompanyContext _context;

        public Repo(CompanyContext context)
        {
            _context = context;
        }
        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return _context.Set<T>()
                .Find(id);
        }
        public void Add(T item)
        {
            _context.Set<T>()
                .Add(item);
        }

        public void Update(T item)
        {
            _context.Set<T>()
                .Update(item);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            _context.Set<T>().Remove(entity);
        }


        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

    }
}
