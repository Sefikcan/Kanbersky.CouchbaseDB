using Kanbersky.CouchbaseDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kanbersky.CouchbaseDB.Abstract
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface ICouchbaseRepository<TEntity>
        where TEntity : BaseCouchbaseEntity, new()
    {
        /// <summary>
        /// Add Item
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> AddAsync(TEntity entity);

        /// <summary>
        /// Remove Item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task RemoveAsync(string id);

        /// <summary>
        /// Upsert Item
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> UpsertAsync(TEntity entity);

        /// <summary>
        /// Get Item By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(string id);

        /// <summary>
        /// Find Item By N1QL query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<TEntity> FindAsync(string query);

        /// <summary>
        ///  Find Items By N1QL query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> FindAllAsync(string query);

        /// <summary>
        /// Pageable Items By N1QL query
        /// </summary>
        /// <param name="query"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<PageableModel<TEntity>> GetPageable(string query, int page, int pageSize);
    }
}
