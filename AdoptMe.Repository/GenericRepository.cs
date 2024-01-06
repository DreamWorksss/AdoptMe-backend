using AdoptMe.Repository.DataContext;
using AdoptMe.Repository.Interfaces;

namespace AdoptMe.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AdoptMeDbContext _context;

        public GenericRepository(AdoptMeDbContext context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public List<T> RetrieveAll()
        {
            return _context.Set<T>().ToList();
        }

        public T? RetrieveById(int entityId)
        {
            return _context.Set<T>().Find(entityId);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
