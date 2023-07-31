using RestaurantList.Models;

namespace RestaurantList.Controllers;

public class CuisinesController : Controller
{
    private readonly RestaurantListContext _db;

    public CuisinesController(RestaurantListContext db)
    {
        _db = db;
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Cuisine cuisine)
    {
        _db.Cuisines.Add(cuisine);
        _db.SaveChanges();
        return RedirectToAction("Index", "Home");
    }

    public ActionResult Details(int id)
    {
        Cuisine cuisine = _db.Cuisines
            .Include(cuisine => cuisine.Restaurants)
            .FirstOrDefault(cuisine => cuisine.CuisineId == id);
        return View(cuisine);
    }

    public ActionResult Edit(int id)
    {
        Cuisine cuisine = _db.Cuisines
            .FirstOrDefault(cuisine => cuisine.CuisineId == id);
        return View(cuisine);
    }

    [HttpPost]
    public ActionResult Edit(Cuisine cuisine)
    {
        _db.Cuisines.Update(cuisine);
        _db.SaveChanges();
        return RedirectToAction("Details", new { id = cuisine.CuisineId });
    }

    public ActionResult Delete(int id)
    {
        Cuisine cuisine = _db.Cuisines
            .FirstOrDefault(cuisine => cuisine.CuisineId == id);
        return View(cuisine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        Cuisine cuisine = _db.Cuisines
            .FirstOrDefault(cuisine => cuisine.CuisineId == id);
        _db.Cuisines.Remove(cuisine);
        _db.SaveChanges();
        return RedirectToAction("Index", "Home");
    }
}