﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks; 

namespace Core.DataAccess.EntityFrameWork
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using TContext context = new();
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {

            using TContext context = new();
            var deleteEntity = context.Entry(entity);
            deleteEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity,bool>>filter)
        {
            using TContext context = new();
            return context.Set<TEntity>().SingleOrDefault(filter)!;

        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter )
        {
            using TContext context = new();
            return filter == null
           ? [.. context.Set<TEntity>()]
           : [.. context.Set<TEntity>().Where(filter)];

        }

        public void Update(TEntity entity)
        {
            using TContext context = new();
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
