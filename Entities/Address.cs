using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PizzaDeliveryApp.Entities;

[Owned]
public class Address
{
    [Required]
    public string Line1 { get; set; }
    
    public string? Line2 { get; set; }
    
    [Required]
    public string PostalCode { get; set; }
    
    [Required]
    public string City { get; set; }
    
    [Required]
    public string Province { get; set; }
    
    [Required]
    public string Country { get; set; }
}