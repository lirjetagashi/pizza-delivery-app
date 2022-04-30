using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PizzaDeliveryApp.Entities;

public class Order : BaseEntity
{
    public List<OrderLine> OrderLines { get; set; } = new();

    public double Total { get; set; }

    public Address? ShippingAddress { get; set; }

    [ForeignKey("UserId")]
    public User? User { get; set; }
    
    [JsonIgnore]
    public long? UserId { get; set; }
    
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