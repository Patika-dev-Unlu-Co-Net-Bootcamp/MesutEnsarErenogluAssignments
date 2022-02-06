using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity: BaseEntity
    {
        Task Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        Task<IList<TEntity>> GetAll();
        Task<IList<TEntity>> GetAllActive();
        Task<TEntity> GetbyId(int Id);
        Task<IList<TEntity>> Get(Expression<Func<TEntity, bool>> filter);
    }
}
