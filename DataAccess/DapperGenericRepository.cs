using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Dapper.Contrib.Extensions;
using Models;

namespace DataAccess
{
    public class DapperGenericRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        public void Add(TEntity entity)
        {
            using (var connection = DbConnect.Connection)
            {
                connection.Insert(entity);
            }
        }

        public void Delete(TEntity entity, Expression<Func<TEntity, bool>> filter = null)
        {
            using (var connection = DbConnect.Connection)
            {
                connection.Delete(entity);
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var connection = DbConnect.Connection)
            {        
                return connection.GetAll<TEntity>().Where(filter.Compile()).SingleOrDefault();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var connection = DbConnect.Connection)
            {
                return filter == null ?
                  connection.GetAll<TEntity>().ToList() :
                  connection.GetAll<TEntity>().Where(filter.Compile()).ToList();
            }
        }

        public void Update(TEntity entity, Expression<Func<TEntity, bool>> filter = null)
        {
            using (var connection = DbConnect.Connection)
            {
                connection.Update(entity);
            }
        }
    }
}
