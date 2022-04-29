using Microsoft.EntityFrameworkCore;
using PizzaDeliveryApp.Entities;

namespace PizzaDeliveryApp.Repositories;

public class ToppingRepository : BaseRepository<Topping>
{
    public ToppingRepository(DbContext dbContext) : base(dbContext)
    {
    }
}