using System.Data;
using PizzaDeliveryApp.Entities;
using PizzaDeliveryApp.Execptions;
using PizzaDeliveryApp.Payloads;
using PizzaDeliveryApp.Repositories;

namespace PizzaDeliveryApp.Services;

public class OrderService
{
    private readonly OrderRepository _orderRepository;

    public OrderService(OrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Order Open()
    {
        var order = new Order
        {
            Status = Status.Open
        };

        return _orderRepository.Create(order);
    }

    public Order CreateLine(long id, OrderLine orderLine)
    {
        var order = FindById(id);
        order.OrderLines.Add(orderLine);
        order.Total = order.OrderLines.Sum(x => x.Item.Price * x.Quantity);
        
        return _orderRepository.Update(order);
    }
    
    public Order UpdateLine(long id, OrderLine orderLine)
    {
        var order = FindById(id);
        var orderLineIndex = order.OrderLines.FindIndex(x => x.Id == orderLine.Id);
        if (orderLineIndex == -1)
        {
            throw new EntityNotFoundException($"No line with ID: {orderLine.Id} exists in order with ID: {id}");
        }
        order.OrderLines[orderLineIndex] = orderLine;
        order.Total = order.OrderLines.Sum(x => x.Item.Price * x.Quantity);
        
        return _orderRepository.Update(order);
    }
    
    public Order DeleteLine(long id, OrderLine orderLine)
    {
        var order = FindById(id);

        order.OrderLines.Remove(orderLine);
        order.Total = order.OrderLines.Sum(x => x.Item.Price * x.Quantity);
        
        return _orderRepository.Update(order);
    }

    public Order Complete(long id, CompleteOrder completeOrder)
    {
        var order = FindById(id);
        
        if (completeOrder.User == null)
        {
            throw new NoNullAllowedException($"Order cannot be completed without a User!");
        }

        if (completeOrder.ShippingAddress == null)
        {
            throw new NoNullAllowedException($"Order cannot be completed without a Shipping Address!");
        }

        order.User = completeOrder.User;
        order.ShippingAddress = completeOrder.ShippingAddress;
        order.Status = Status.Complete;
        
        return _orderRepository.Update(order);
    }
    
    public Order Prepare(long id)
    {
        var order = FindById(id);
        order.Status = Status.Preparing;
        
        return _orderRepository.Update(order);
    }
    
    public Order OutForDelivery(long id)
    {
        var order = FindById(id);
        order.Status = Status.OutForDelivery;
        
        return _orderRepository.Update(order);
    }
    
    public Order Delivered(long id)
    {
        var order = FindById(id);
        order.Status = Status.Delivered;
        
        return _orderRepository.Update(order);
    }

    private Order FindById(long id)
    {
        var order = _orderRepository.FindById(id);
        
        if (order == null)
        {
            throw new EntityNotFoundException($"Order with id {id} not found!");
        }

        return order;
    }
    
}