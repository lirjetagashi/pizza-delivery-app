using Microsoft.EntityFrameworkCore;
using PizzaDeliveryApp.Entities;

namespace PizzaDeliveryApp.Repositories;

public abstract class BaseRepository<T> where T : BaseEntity
{
    private readonly DbContext _dbContext;

    protected BaseRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public T Create(T obj)
    {
        var entity = _dbContext.Add(obj);
        _dbContext.SaveChanges();

        return entity.Entity;
    }

    public void Delete(T obj)
    {
        _dbContext.Remove(obj);
        _dbContext.SaveChanges();
    }

    public T Update(T obj)
    {
        var entity = _dbContext.Update(obj);
        _dbContext.SaveChanges();

        return entity.Entity;
    }

    public IEnumerable<T> FindAll()
    {
        return _dbContext.Set<T>().ToList();
    }

    public T? FindById(long id)
    {
        return _dbContext.Set<T>().FirstOrDefault(x => x.Id == id);
    }
}