using PizzaDeliveryApp.Entities;
using PizzaDeliveryApp.Repositories;

namespace PizzaDeliveryApp.Services;

public class OrderLineService
{
    private readonly OrderLineRepository _orderLineRepository;

    public OrderLineService(OrderLineRepository orderLineRepository)
    {
        _orderLineRepository = orderLineRepository;
    }

    public OrderLine CreateLine(OrderLine orderLine)
    {
        return _orderLineRepository.Create(orderLine);
    }

    public OrderLine UpdateLine(OrderLine orderLine)
    {
        return _orderLineRepository.Update(orderLine);
    }

    public void DeleteLine(OrderLine orderLine)
    {
        _orderLineRepository.Delete(orderLine);
    }
}