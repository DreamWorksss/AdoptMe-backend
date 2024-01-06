namespace AdoptMe.Repository.Interfaces
{
    /// <summary>
    /// Provides access to Generic Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Retrieves the specified entity by its id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns>The entity if exists, null otherwise</returns>
        T? RetrieveById(int entityId);

        /// <summary>
        /// Retrieves a list of all entities from the database
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortDesc"></param>
        /// <returns>List of entities</returns>
        List<T> RetrieveAll();

        /// <summary>
        /// Adds a new entity to the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>The new added entity</returns>
        T Add(T entity);

        /// <summary>
        /// Updates the entity from the database 
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Deletes the entity from the database
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
    }
}
