using Microsoft.EntityFrameworkCore;

namespace PizzaDeliveryApp.Entities;

public class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public AppDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var connectionString = _configuration.GetConnectionString("WebApiDatabase");
        options.EnableSensitiveDataLogging();
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        seedUser(modelBuilder);
        seedUserAddress(modelBuilder);
        seedToppings(modelBuilder);
        seedItems(modelBuilder);
        seedItemTopping(modelBuilder);

        modelBuilder.Entity<Order>().OwnsOne(o => o.ShippingAddress, a => a.ToTable("OrderAddresses"));
    }

    public DbSet<Order>? Orders { get; set; }

    public DbSet<OrderLine>? OrderLines { get; set; }

    public DbSet<Item>? Items { get; set; }

    public DbSet<Topping>? Toppings { get; set; }

    private void seedItemTopping(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().HasMany(i => i.Toppings)
            .WithMany(t => t.Items)
            .UsingEntity(x => x.ToTable("ItemTopping").HasData(
                // Item 1
                new { ItemsId = 1L, ToppingsId = 1L },
                new { ItemsId = 1L, ToppingsId = 2L },
                new { ItemsId = 1L, ToppingsId = 4L },
                new { ItemsId = 1L, ToppingsId = 7L },
                // Item 2
                new { ItemsId = 2L, ToppingsId = 1L },
                new { ItemsId = 2L, ToppingsId = 2L },
                new { ItemsId = 2L, ToppingsId = 3L },
                new { ItemsId = 2L, ToppingsId = 4L },
                new { ItemsId = 2L, ToppingsId = 5L },
                new { ItemsId = 2L, ToppingsId = 7L },
                new { ItemsId = 2L, ToppingsId = 8L },
                new { ItemsId = 2L, ToppingsId = 9L },
                new { ItemsId = 2L, ToppingsId = 10L }
            ));
    }

    private void seedItems(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().HasData(new List<Item>
        {
            new()
            {
                Id = 1,
                Name = "Medium Chicken Special Pizza",
                Price = 13.99
            },
            new()
            {
                Id = 2,
                Name = "Medium Greek Pizza",
                Price = 12.99,
            }
        });
    }

    private void seedToppings(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Topping>().HasData(new List<Topping>
        {
            new() { Id = 1, Name = "Chicken" },
            new() { Id = 2, Name = "Mushrooms" },
            new() { Id = 3, Name = "Feta Cheese" },
            new() { Id = 4, Name = "Cheese" },
            new() { Id = 5, Name = "Onions" },
            new() { Id = 6, Name = "Peperoni" },
            new() { Id = 7, Name = "Tomato Sauce" },
            new() { Id = 8, Name = "Green Pepper" },
            new() { Id = 9, Name = "Green Olives" },
            new() { Id = 10, Name = "Black Olives" },
        });
    }

    private void seedUser(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(new User
        {
            Id = 1L,
            FirstName = "Bob",
            LastName = "Smith",
            Email = "bob.smith@gmail.com",
            PhoneNumber = "1231231234",
        });
    }

    private void seedUserAddress(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().OwnsOne(u => u.Address, x => x.ToTable("UserAddresses").HasData(new
        {
            UserId = 1L,
            City = "Waterloo",
            Country = "Canada",
            Line1 = "123 King St",
            PostalCode = "N1L 2L1",
            Province = "ON"
        }));
    }
}