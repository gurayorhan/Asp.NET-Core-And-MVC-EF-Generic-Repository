using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Blog.YazilimciPlatformu.Models;

namespace Blog.YazilimciPlatformu.Repository
{
    public interface IGenericRepository<T>:IDisposable where T:class
    {
        T Kaydet(T entity);
        T Getir(int id);
        T Getir(Expression<Func<T, bool>> predicate);
        List<T> Listele();
        List<T> Listele(Expression<Func<T, bool>> predicate);
        IQueryable<TResult> GetAllSelect<TResult>(Expression<Func<T, TResult>> select);
        IQueryable<TResult> GetAllSelect<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> select);
        bool Sil(int id);
        bool Sil(T entity);
        T Guncelle(T entity);
        int KayitSayisi();
        int KayitSayisi(Expression<Func<T, bool>> predicate);

    }
}
