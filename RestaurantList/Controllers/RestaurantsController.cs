using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantList.Models;

namespace RestaurantList.Controllers;

public class RestaurantsController : Controller
{
    private readonly RestaurantListContext _db;

    public RestaurantsController(RestaurantListContext db)
    {
        _db = db;
    }

    public ActionResult Create(int id)
    {
        ViewBag.CuisineId = id;
        return View();
    }

    [HttpPost]
    public ActionResult Create(Restaurant restaurant)
    {
        if (restaurant.CuisineId == 0)
            return RedirectToAction("Create");
        _db.Restaurants.Add(restaurant);
        _db.SaveChanges();
        return RedirectToAction("Details", "Cuisines", new { id = restaurant.CuisineId });
    }

    public ActionResult Details(int id)
    {
        Restaurant restaurant = _db.Restaurants
            .Include(restaurant => restaurant.Reviews)
            .FirstOrDefault(restaurant => restaurant.RestaurantId == id);
        return View(restaurant);
    }

    public ActionResult Edit(int id)
    {
        Restaurant restaurant = _db.Restaurants
            .FirstOrDefault(restaurant => restaurant.RestaurantId == id);
        ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name", restaurant.CuisineId);
        return View(restaurant);
    }

    [HttpPost]
    public ActionResult Edit(Restaurant restaurant)
    {
        _db.Restaurants.Update(restaurant);
        _db.SaveChanges();
        return RedirectToAction("Details", "Cuisines", new { id = restaurant.CuisineId });
    }

    public ActionResult Delete(int id)
    {
        Restaurant restaurant = _db.Restaurants
            .FirstOrDefault(restaurant => restaurant.RestaurantId == id);
        int cId = restaurant.CuisineId;
        _db.Restaurants.Remove(restaurant);
        _db.SaveChanges();
        return RedirectToAction("Details", "Cuisines", new { id = cId });
    }
}