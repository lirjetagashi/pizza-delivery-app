using System.ComponentModel.DataAnnotations;

namespace PizzaDeliveryApp.Entities;

public class Topping : BaseEntity
{
    [Required]
    public string Name { get; set; }

    public List<Item> Items = new();
    
}