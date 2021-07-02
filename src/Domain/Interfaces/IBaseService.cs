using FluentValidation;
using System.Collections.Generic;
using Cobrancas.Domain.Entities;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;

namespace Cobrancas.Domain.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter);

        Task<TEntity> GetAsync(string id);

        Task<TResponse> AddAsync<TRequest, TResponse, TValidator>(TRequest inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TRequest : class
            where TResponse : class;

        Task UpdateAsync<TRequest, TValidator>(string id, TRequest inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TRequest : class;

        Task RemoveAsync(string id);
    }
}