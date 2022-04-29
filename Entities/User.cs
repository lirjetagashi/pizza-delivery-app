using System.ComponentModel.DataAnnotations;

namespace PizzaDeliveryApp.Entities;

public class User : BaseEntity
{
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [Required]
    public string Email { get; set; }
    
    [Required]
    public string PhoneNumber { get; set; }
    
    public Address Address { get; set; }
}