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
        public GenericRules(ProyectoPruebaDbContext db)
        {
            _db = db;
        }

        public IEnumerable<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }
        public T GetById(object id)
        {
            return _db.Set<T>().Find(id);
        }
        public void Insert(T obj)
        {
             _db.Set<T>().Add(obj);
             _db.SaveChanges();
        }
        public void Update(T obj)
        {
            _db.Set<T>().Attach(obj);
            _db.Entry(obj).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public void Delete(object id)
        {
            T existing = _db.Set<T>().Find(id);
            _db.Set<T>().Remove(existing);
            _db.SaveChanges();
        }
    }

}