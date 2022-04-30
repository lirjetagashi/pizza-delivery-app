using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PizzaDeliveryApp.Entities;

public class OrderLine : BaseEntity
{
    [Required] 
    [ForeignKey("ItemId")]
    public Item Item { get; set; }
    
    [JsonIgnore]
    public long ItemId { get; set; }
    
    [Required] 
    public int Quantity { get; set; }
}