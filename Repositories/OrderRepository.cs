using Microsoft.EntityFrameworkCore;
using PizzaDeliveryApp.Entities;

namespace PizzaDeliveryApp.Repositories;

public class OrderRepository : BaseRepository<Order>
{
    public OrderRepository(DbContext dbContext) : base(dbContext)
    {
    }
}