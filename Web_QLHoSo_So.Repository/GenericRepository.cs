﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Web_QLHoSo_So.Model.Entities;

namespace Web_QLHoSo_So.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity    
    {
        private readonly WebDbContext _context;
        DbSet<T> _dbSet;
        public GenericRepository(WebDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList().Where(x=>x.DeleteAt==null).OrderByDescending(x=>x.CreateAt).ThenByDescending(x => x.UpdateAt); ;
        }
        public T GetbyId(Guid id)
        {
            return _dbSet.Where(x=>x.Id==id && x.DeleteAt==null).FirstOrDefault();
        }
        public bool Add(T entity)
        {
            if (!_dbSet.Any(e => e == entity))
            {
                entity.CreateAt = DateTime.Now;
                _dbSet.Add(entity);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Update(T entity)
        {
            entity.UpdateAt = DateTime.Now;
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                var existingEntity = _dbSet.Find(GetKeyValues(entity).ToArray());
                if (existingEntity == null)
                {
                    return false;
                }
                entity.CreateAt = existingEntity.CreateAt;
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            }
            //_context.Entry(entity).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return true;
        }
        private IEnumerable<object> GetKeyValues(T entity)
        {
            var keyProperties = _context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties;
            foreach (var property in keyProperties)
            {
                yield return property.PropertyInfo.GetValue(entity);
            }
        }
        public bool Delete(Guid id)
        {
            var category = _dbSet.Find(id);
            if (category == null)
            {
                return false;
            }
            _dbSet.Remove(category);
            _context.SaveChanges();
            return true;
        }
        public bool softDelete(Guid id)
        {
            var category = _dbSet.Find(id);
            if (category == null)
            {
                return false;
            }
            category.DeleteAt = DateTime.Now;
            _dbSet.Update(category);
            _context.SaveChanges();
            return true;
        }

        public T FindOne(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).FirstOrDefault();
        }
    }
}
