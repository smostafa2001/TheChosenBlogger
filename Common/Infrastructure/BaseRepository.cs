using Common.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Common.Infrastructure;

public class BaseRepository<TKey, T>(DbContext context) : IRepository<TKey, T> where T : DomainBase<TKey>
{
    public void Create(T entity) => context.Add<T>(entity);

    public bool Exists(Expression<Func<T, bool>> expression) => context.Set<T>().Any(expression);

    public T Get(TKey id) => context.Find<T>(id);

    public List<T> GetAll() => [.. context.Set<T>()];
}
