using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Cobrancas.Domain.Entities;

namespace Cobrnacas.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task InsertAsync(TEntity obj);

        Task UpdateAsync(string id, TEntity inputModel);

        Task DeleteAsync(string id);

        Task<IList<TEntity>> SelectAsync(Expression<Func<TEntity, bool>>  filter);

        Task<TEntity> SelectAsync(string id);
    }
}