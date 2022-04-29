using System.ComponentModel.DataAnnotations;

namespace PizzaDeliveryApp.Entities;

public class OrderLine : BaseEntity
{
    [Required] 
    public Item Item { get; set; }

    [Required] 
    public int Quantity { get; set; }
}