using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bulky.DataAccess.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _dbContext;
    internal DbSet<T> dbset;

    public Repository(ApplicationDbContext dbContext)
    {
        _dbContext= dbContext;
        this.dbset = _dbContext.Set<T>();
        // inject category in the product item based on forign key
        _dbContext.Products.Include(p => p.Category);
    }
    public void Add(T entity)
    {
       dbset.Add(entity);
    }

    public T Get(Expression <Func<T, bool>> filter , string? includeProperties = null)
    {
        IQueryable<T> query = dbset;
        query = query.Where(filter);
        if (!(string.IsNullOrEmpty(includeProperties)))
        {
            foreach (var includeprop in includeProperties.Split(new char[] { ',' }
            , StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeprop);
            }

        }
        return query.FirstOrDefault();
    }

    public IEnumerable<T> GetAll( string? includeProperties = null)
    {
        IQueryable<T> query = dbset;
        if(! (string.IsNullOrEmpty(includeProperties)))
        {
            foreach(var includeprop in includeProperties.Split(new char[] {','} 
            ,StringSplitOptions.RemoveEmptyEntries)) 
            {
                query = query.Include(includeprop); 
            }

        }
        return query.ToList();
    }

    public void Remove(T entity)
    {
       dbset.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entity)
    {
       dbset.RemoveRange(entity);
    }

    public void UpdateAll(IEnumerable<T> entities)
    {
       dbset.UpdateRange(entities);
    }
}
