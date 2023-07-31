namespace RestaurantList.Models;

public class RestaurantListContext : DbContext
{
    public DbSet<Cuisine> Cuisines { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Review> Reviews { get; set; }

    public RestaurantListContext(DbContextOptions options) : base(options)
    {}
}