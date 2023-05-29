namespace SaviaHomeTest.Application.Abstractions
{
    /// <summary>
    /// Generic repository interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAppRepository<T> where T : class
    {
        /// <summary>
        /// Get all T
        /// </summary>
        /// <returns>IEnumerable<T></returns>
        Task<IEnumerable<T>> GetAll();

        /// <summary>
        /// Gets T by id
        /// </summary>
        /// <param name="id">
        /// id as Guid
        /// </param>
        /// <returns>T</returns>
        Task<T> GetById(Guid id);
        
        /// <summary>
        /// Saves T
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>T</returns>
        Task<T> Save(T entity);
        
        /// <summary>
        /// Updates T
        /// </summary>
        /// <param name="entity"></param>
        Task Update(T entity);
        
        /// <summary>
        /// Deletes T
        /// </summary>
        /// <param name="entity"></param>
        Task Delete(T entity);
    }
}
