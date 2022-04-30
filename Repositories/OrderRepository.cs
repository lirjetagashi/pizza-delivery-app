using Microsoft.EntityFrameworkCore;
using PizzaDeliveryApp.Entities;
using PizzaDeliveryApp.Execptions;

namespace PizzaDeliveryApp.Repositories;

public class OrderRepository : BaseRepository<Order>
{

    public OrderRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
    
    public override List<Order> FindAll()
    {
        return DbContext.Orders!
            .Include("OrderLines")
            .Include("OrderLines.Item")
            .Include("User")
            .ToList();
    }

    public override Order Update(Order obj)
    {
        obj.OrderLines.ForEach(x =>
        {
            x.ItemId = x.Item.Id;
            x.Item = null!;
        }); // Prevent Item from updating
        
        return base.Update(obj);
    }

    public override Order FindById(long id)
    {
        return DbContext.Orders!
                   .Include("OrderLines")
                   .Include("OrderLines.Item")
                   .Include("User")
                   .AsNoTracking()
                   .FirstOrDefault(x => x.Id == id) 
               ?? throw new EntityNotFoundException("No Entity found with Id: " + id);
    }
    
    public Order FindByIdTracked(long id)
    {
        return DbContext.Orders!.FirstOrDefault(x => x.Id == id) ?? throw new EntityNotFoundException("No Entity found with Id: " + id);
    }
}