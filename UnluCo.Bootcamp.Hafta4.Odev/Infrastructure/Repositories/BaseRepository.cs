using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<TEntity> dataSet;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            dataSet = _context.Set<TEntity>();
        }
        public async Task Add(TEntity entity)
        {
            await dataSet.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            entity.IsActive = false;
            dataSet.Update(entity);
        }

        public async Task<IList<TEntity>> Get(Expression<Func<TEntity, bool>> filter)
        {
           return await dataSet.Where(filter).ToListAsync();
        }

        public async Task<IList<TEntity>> GetAll()
        {
            return await dataSet.ToListAsync();
        }
        public async Task<IList<TEntity>> GetAllActive()
        {

            return await dataSet.Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<TEntity> GetbyId(int Id)
        {
            var entity = await dataSet.SingleOrDefaultAsync(x => x.Id == Id);
            return entity;
        }

        public void Update(TEntity entity)
        {
            dataSet.Update(entity);
        }
    }
}
