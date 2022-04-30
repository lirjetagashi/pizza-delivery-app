using Microsoft.EntityFrameworkCore;
using PizzaDeliveryApp.Entities;

namespace PizzaDeliveryApp.Repositories;

public class OrderLineRepository : BaseRepository<OrderLine>
{
    public OrderLineRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}