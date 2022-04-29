using PizzaDeliveryApp.Entities;

namespace PizzaDeliveryApp.Payloads;

public class CompleteOrder
{
    public Address ShippingAddress { get; set; }

    public User User { get; set; }
}