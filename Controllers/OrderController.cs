using Microsoft.AspNetCore.Mvc;
using PizzaDeliveryApp.Entities;
using PizzaDeliveryApp.Payloads;
using PizzaDeliveryApp.Services;

namespace PizzaDeliveryApp.Controllers;

[ApiController]
[Route("/order")]
public class OrderController : ControllerBase
{

    private readonly OrderService _orderService;

    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    [Route("open")]
    public Order Open()
    {
        return _orderService.Open();
    }
    
    [HttpPut]
    [Route("{id}/add-line")]
    public Order AddLine(long id, OrderLine orderLine)
    {
        return _orderService.CreateLine(id, orderLine);
    }
    
    [HttpPut]
    [Route("{id}/set-line")]
    public Order SetLine(long id, OrderLine orderLine)
    {
        return _orderService.UpdateLine(id, orderLine);
    }
    
    [HttpPut]
    [Route("{id}/remove-line")]
    public Order RemoveLine(long id, OrderLine orderLine)
    {
        return _orderService.DeleteLine(id, orderLine);
    }
    
    [HttpPut]
    [Route("{id}/complete")]
    public Order Complete(long id, CompleteOrder completeOrder)
    {
        return _orderService.Complete(id, completeOrder);
    }
    
    [HttpPut]
    [Route("{id}/prepare")]
    public Order Prepare(long id)
    {
        return _orderService.Prepare(id);
    }
    
    [HttpPut]
    [Route("{id}/out-for-delivery")]
    public Order OutForDelivery(long id)
    {
        return _orderService.OutForDelivery(id);
    }
    
    [HttpPut]
    [Route("{id}/delivered")]
    public Order Delivered(long id)
    {
        return _orderService.Delivered(id);
    }
    
}