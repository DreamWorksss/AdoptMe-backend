namespace AdoptMe.Service.Interfaces
{
    interface IGenericService<T> where T : class
    {
        /// <summary>
        /// Retrieves specific entity by id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns>The entity if found, null otherwise</returns>
        T? RetrieveById(int entityId);
        /// <summary>
        /// Retrieves a list of all entities
        /// </summary>
        /// <returns>The list of all entities</returns>
        List<T> RetrieveAll();
        /// <summary>
        /// Adds the entity to the database
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);
        /// <summary>
        /// Updates the existing entity
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);
        /// <summary>
        /// Deletes the existing entity from the database
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
    }
}
