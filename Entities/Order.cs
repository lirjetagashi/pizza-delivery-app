using System.ComponentModel.DataAnnotations;

namespace PizzaDeliveryApp.Entities;

public class Order : BaseEntity
{
    public List<OrderLine> OrderLines { get; set; } = new();

    public double Total { get; set; }

    public Address? ShippingAddress { get; set; }

    public User? User { get; set; }
    
    [Required]
    public Status Status { get; set; }
}

public enum Status
{
    Open,

    Complete,

    Preparing,

    OutForDelivery,

    Delivered
}