using System.ComponentModel.DataAnnotations;

namespace PizzaDeliveryApp.Entities;

public abstract class BaseEntity
{
    [Key] public long Id { get; set; }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == this.GetType() && ((BaseEntity)obj).Id == Id;
    }
}