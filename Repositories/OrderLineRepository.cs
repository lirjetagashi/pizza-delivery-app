using Microsoft.EntityFrameworkCore;
using PizzaDeliveryApp.Entities;

namespace PizzaDeliveryApp.Repositories;

public class OrderLineRepository : BaseRepository<OrderLine>
{
    public OrderLineRepository(DbContext dbContext) : base(dbContext)
    {
    }
}