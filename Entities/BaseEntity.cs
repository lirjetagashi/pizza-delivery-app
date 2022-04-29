using System.ComponentModel.DataAnnotations;

namespace PizzaDeliveryApp.Entities;

public abstract class BaseEntity
{
    [Key]
    public long Id { get; set; }
}