using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Common.Infrastructure;

public interface IRepository<in TKey, T> where T : DomainBase<TKey>
{
    void Create(T entity);
    T Get(TKey id);
    List<T> GetAll();
    bool Exists(Expression<Func<T, bool>> expression);
}
