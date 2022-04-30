using Microsoft.EntityFrameworkCore;
using PizzaDeliveryApp.Entities;
using PizzaDeliveryApp.Execptions;

namespace PizzaDeliveryApp.Repositories;

public abstract class BaseRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext DbContext;

    protected BaseRepository(AppDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public virtual T Create(T obj)
    {
        var entity = DbContext.Add(obj);
        DbContext.SaveChanges();

        return entity.Entity;
    }

    public virtual void Delete(T obj)
    {
        DbContext.Remove(obj);
        DbContext.SaveChanges();
    }

    public virtual T Update(T obj)
    {
        DbContext.Update(obj);
        DbContext.SaveChanges();

        return FindById(obj.Id);
    }

    public virtual IEnumerable<T> FindAll()
    {
        return DbContext.Set<T>().ToList();
    }

    public virtual T FindById(long id)
    {
        return DbContext.Set<T>().AsNoTracking().FirstOrDefault(x => x.Id == id) ?? throw new EntityNotFoundException("No Entity found with Id: " + id);
    }
}