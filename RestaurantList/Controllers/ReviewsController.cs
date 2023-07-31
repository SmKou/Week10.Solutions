using RestaurantList.Models;

namespace RestaurantList.Controllers;

public class ReviewsController : Controller
{
    private readonly RestaurantListContext _db;

    public ReviewsController(RestaurantListContext db)
    {
        _db = db;
    }

    public ActionResult Create(int id)
    {
        Restaurant restaurant = _db.Restaurants
            .FirstOrDefault(restaurant => restaurant.RestaurantId == id);
        ViewBag.RestaurantId = id;
        ViewBag.CuisineId = restaurant.CuisineId;
        return View();
    }

    [HttpPost]
    public ActionResult Create(Review review)
    {
        if (review.Rating < 0 || review.Rating > 6)
            return RedirectToAction("Create", new { id = review.RestaurantId });
        _db.Reviews.Add(review);
        _db.SaveChanges();
        return RedirectToAction("Details", "Restaurants", new { id = review.RestaurantId });
    }

    public ActionResult Details(int id)
    {
        Review review = _db.Reviews
            .Include(review => review.Restaurant)
            .FirstOrDefault(review => review.ReviewId == id);
        return View(review);
    }

    public ActionResult Edit(int id)
    {
        Review review = _db.Reviews
            .FirstOrDefault(review => review.ReviewId == id);
        return View(review);
    }

    [HttpPost]
    public ActionResult Edit(Review review)
    {
        _db.Reviews.Update(review);
        _db.SaveChanges();
        return RedirectToAction("Details", new { id = review.ReviewId });
    }

    public ActionResult Delete(int id)
    {
        Review review = _db.Reviews
            .FirstOrDefault(review => review.ReviewId == id);
        int rId = review.RestaurantId;
        _db.Reviews.Remove(review);
        _db.SaveChanges();
        return RedirectToAction("Details", "Restaurants", new { id = rId });
    }
}