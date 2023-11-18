using AdoptMe.Repository;
using AdoptMe.Service.Interfaces;

namespace AdoptMe.Service
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly GenericRepository<T> _repository;

        public GenericService(GenericRepository<T> repository)
        {
            _repository = repository;
        }

        public void Add(T entity)
        {
            _repository.Add(entity);
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
        }

        public List<T> RetrieveAll()
        {
            return _repository.RetrieveAll();
        }

        public T? RetrieveById(int entityId)
        {
            return _repository.RetrieveById(entityId);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }
    }
}
