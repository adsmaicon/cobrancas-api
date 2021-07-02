using System;
using AutoMapper;
using FluentValidation;
using System.Collections.Generic;
using Cobrancas.Domain.Entities;
using Cobrancas.Domain.Interfaces;
using Cobrnacas.Domain.Interfaces;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Cobrancas.Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<TEntity> _repository;
        public BaseService(IMapper mapper, IBaseRepository<TEntity> repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TResponse> AddAsync<TRequest, TResponse, TValidator>(TRequest request)
            where TValidator : AbstractValidator<TEntity>
            where TRequest : class
            where TResponse : class
        {
            TEntity entity = _mapper.Map<TEntity>(request);
            await Activator.CreateInstance<TValidator>().ValidateAndThrowAsync(entity);

            await _repository.InsertAsync(entity);

            TResponse outputModel = _mapper.Map<TResponse>(entity);
            return outputModel;
        }

        public async Task UpdateAsync<TRequest, TValidator>(string id, TRequest request)
            where TValidator : AbstractValidator<TEntity>
            where TRequest : class
        {
            TEntity entity = _mapper.Map<TEntity>(request);
            await Activator.CreateInstance<TValidator>().ValidateAndThrowAsync(entity);

            await _repository.UpdateAsync(id, entity);
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _repository.SelectAsync(filter);
        }

        public async Task<TEntity> GetAsync(string id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task RemoveAsync(string id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}