namespace RestaurantList.Models;

public class Review
{
    public int ReviewId { get; set; }
    public string Summary { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }

    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
}