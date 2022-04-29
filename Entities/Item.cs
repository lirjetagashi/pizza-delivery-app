using System.ComponentModel.DataAnnotations;

namespace PizzaDeliveryApp.Entities;

public class Item : BaseEntity
{
    [Required]
    public string? Name { get; set; }

    [Required]
    public double Price { get; set; }

    [Required]
    public virtual List<Topping> Toppings { get; set; } = new();

}