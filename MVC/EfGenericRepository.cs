using RezervasyonMvc.MvcUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace RezervasyonMvc.MvcUI.Repository
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T:class
    {
        public RezervasyonMvcContext context = new RezervasyonMvcContext();
        public T Getir(int id)
        {
            return context.Set<T>().Find(id);
        }

        public T Guncelle(T entity)
        {
            context.Set<T>().AddOrUpdate(entity);
            context.SaveChanges();
            return entity;
        }

        public T Kaydet(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
            return entity;
        }

        public List<T> Listele()
        {
            return context.Set<T>().AsNoTracking().ToList();
        }

        public List<T> Listele(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().AsNoTracking().Where(predicate).ToList();
        }

        public bool Sil(int id)
        {
            return Sil(Getir(id));
        }

        public bool Sil(T entity)
        {
            context.Set<T>().Remove(entity);
            return context.SaveChanges() > 0;
        }
        public T Getir(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate).SingleOrDefault();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

        public int KayitSayisi()
        {
            return context.Set<T>().Count();
        }

        public int KayitSayisi(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate).Count();
        }

        public IQueryable<TResult> GetAllSelect<TResult>(Expression<Func<T, TResult>> select)
        {
            return context.Set<T>().Select(select);
        }

        public IQueryable<TResult> GetAllSelect<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> select)
        {
            return context.Set<T>().Where(predicate).Select(select);
        }
    }
}