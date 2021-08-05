using Couchbase.Core;
using Couchbase.Extensions.DependencyInjection;
using Kanbersky.CouchbaseDB.Abstract;
using Kanbersky.CouchbaseDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanbersky.CouchbaseDB.Concrete
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class CouchbaseRepository<TEntity> : ICouchbaseRepository<TEntity>
        where TEntity : BaseCouchbaseEntity, new()
    {
        private readonly IBucketProvider _bucketProvider;
        private readonly IBucket _bucket;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="bucketProvider"></param>
        public CouchbaseRepository(IBucketProvider bucketProvider)
        {
            _bucketProvider = bucketProvider;
            _bucket = _bucketProvider.GetBucket(typeof(TEntity).Name);
        }

        /// <summary>
        /// Add Item
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> AddAsync(TEntity entity)
        {
            var results = await _bucket.InsertAsync(entity.Id, entity);
            return results.Success;
        }

        /// <summary>
        /// Get Item By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> GetByIdAsync(string id)
        {
            var result = await _bucket.GetDocumentAsync<TEntity>(id);
            return result.Content;
        }

        /// <summary>
        /// Find Item By N1QL query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<TEntity> FindAsync(string query)
        {
            var results = await _bucket.QueryAsync<TEntity>(query);
            if (results.Success)
            {
                return results.Rows.FirstOrDefault();
            }

            return null;
        }

        /// <summary>
        ///  Find Items By N1QL query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> FindAllAsync(string query)
        {
            var results = await _bucket.QueryAsync<TEntity>(query);
            if (results.Success)
            {
                return results.Rows;
            }

            return new List<TEntity>();
        }

        /// <summary>
        /// Remove Item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task RemoveAsync(string id)
        {
            await _bucket.RemoveAsync(id);
        }

        /// <summary>
        /// Upsert Item
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> UpsertAsync(TEntity entity)
        {
            var result = await _bucket.UpsertAsync(entity.Id, entity);
            return result.Success;
        }

        /// <summary>
        /// Pageable Items By N1QL query
        /// </summary>
        /// <param name="query"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<PageableModel<TEntity>> GetPageable(string query, int page, int pageSize)
        {
            var results = await _bucket.QueryAsync<TEntity>(query);
            if (results.Success)
            {
                return new PageableModel<TEntity>
                {
                    Items = results.Rows,
                    PageNumber = page,
                    PageSize = results.Rows.Count,
                    TotalItemCount = Convert.ToInt32(results.Metrics.SortCount),
                    TotalPageCount = (int)Math.Ceiling(Convert.ToDouble(results.Metrics.SortCount) / pageSize)
                };
            }

            return new PageableModel<TEntity>();
        }
    }
}
