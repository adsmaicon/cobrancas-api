using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Cobrancas.Domain.Entities;
using Cobrancas.Infra.Data.Database;
using Cobrnacas.Domain.Interfaces;
using MongoDB.Driver;

namespace Cobrnacas.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IMongoCollection<TEntity> _collection;

        public BaseRepository(MongoDatabase<TEntity> database)
        {
            _collection = database.GetCollection();
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(c => c.Id == id);
        }

        public async Task InsertAsync(TEntity obj)
        {
            await _collection.InsertOneAsync(obj);
        }

        public async Task<IList<TEntity>> SelectAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _collection.Find<TEntity>(filter).ToListAsync();
        }

        public async Task<TEntity> SelectAsync(string id)
        {
            return await _collection.Find<TEntity>(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(string id, TEntity obj)
        {
            await _collection.ReplaceOneAsync<TEntity>(c => c.Id == id, obj);
        }
    }
}