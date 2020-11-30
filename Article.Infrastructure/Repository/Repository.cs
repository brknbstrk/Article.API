using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Article.Infrastructure
{
    public class Repository<TEntity, PKType> : IRepository<TEntity, PKType>
        where TEntity : class, IEntity<PKType>
        where PKType : IComparable
    {
        private readonly AppDbContext _appDbContext;
        public Repository()
        {

        }
        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public TEntity Add(TEntity entity)
        {
            _appDbContext.Add<TEntity>(entity);
            return entity;
        }

        public void Commit()
        {
            if (_appDbContext == null)
                throw new ArgumentNullException("DataContext");

            this._appDbContext.SaveChanges();
        }

        public TEntity Delete(PKType id)
        {
            TEntity entity = GetById(id);
            if (entity != null)
            {
                _appDbContext.Remove<TEntity>(entity);
            }
            return entity;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _appDbContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(PKType id)
        {
            return _appDbContext.Set<TEntity>().Find(id);
        }

        public TEntity Update(TEntity entity)
        {
            var updateData = _appDbContext.Attach<TEntity>(entity);
            updateData.State = EntityState.Modified;
            return entity;
        }
    }
}
