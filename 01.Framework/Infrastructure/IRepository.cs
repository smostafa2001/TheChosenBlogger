using _01.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace _01.Framework.Infrastructure
{
    public interface IRepository<in TKey, T> where T : DomainBase<TKey>
    {
        void Create(T entity);
        T Get(TKey id);
        List<T> GetAll();
        bool DoesExist(Expression<Func<T, bool>> expression);
    }
}
