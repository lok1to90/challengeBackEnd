using log4net;
using ProyectoPrueba.IRules;
using ProyectoPrueba.ProyectoDbContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoPrueba.Rules
{
    public class GenericRules<T> : IGenericRules<T> where T : class
    {
        private readonly ProyectoPruebaDbContext _db;
        private readonly ILog _logger;

        public GenericRules(ProyectoPruebaDbContext db, ILog logger)
        {
            _db = db;
            _logger = logger;
        }

        public virtual IEnumerable<T> GetAll()
        {
            try
            {
                return _db.Set<T>().ToList();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }
        public virtual T GetById(object id)
        {
            try
            {
                return _db.Set<T>().Find(id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }
        public virtual void Insert(T obj)
        {
            try
            {
                _db.Set<T>().Add(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }
        public virtual void Update(T obj)
        {
            try
            {
                _db.Set<T>().Attach(obj);
                _db.Entry(obj).State = EntityState.Modified;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }
        public virtual void Delete(object id)
        {
            try
            {
                T existing = _db.Set<T>().Find(id);
                _db.Set<T>().Remove(existing);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }
    }

}