using Microsoft.EntityFrameworkCore;
using PizzaDeliveryApp.Entities;

namespace PizzaDeliveryApp.Repositories;

public class ItemRepository : BaseRepository<Item>
{
    public ItemRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}