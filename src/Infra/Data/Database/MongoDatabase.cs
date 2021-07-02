using Cobrancas.Domain.Entities;
using Cobrancas.Domain.Interfaces;
using MongoDB.Driver;

namespace Cobrancas.Infra.Data.Database
{
    public class MongoDatabase<TEntity> : MongoClient where TEntity : BaseEntity
    {
        private readonly ICobrancasDatabaseSettings _settings;
        
        public MongoDatabase(ICobrancasDatabaseSettings settings)
            : base(MongoClientSettings.FromConnectionString(settings.ConnectionString))
        {
            _settings = settings;
        }

        public IMongoCollection<TEntity> GetCollection()
        {
            var database = base.GetDatabase(_settings.DatabaseName);
            return database.GetCollection<TEntity>(_settings.CobrancasCollectionName);
        }

    }
}
