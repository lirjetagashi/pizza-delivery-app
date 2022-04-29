using Microsoft.EntityFrameworkCore;
using PizzaDeliveryApp.Entities;

namespace PizzaDeliveryApp.Repositories;

public class ItemRepository : BaseRepository<Item>
{
    public ItemRepository(DbContext dbContext) : base(dbContext)
    {
    }
}