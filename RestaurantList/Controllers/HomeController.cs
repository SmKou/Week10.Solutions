using RestaurantList.Models;

namespace RestaurantList.Controllers;

public class HomeController : Controller
{
    private readonly RestaurantListContext _db;

    public HomeController(RestaurantListContext db)
    {
        _db = db;
    }

    public ActionResult Index()
    {
        List<Cuisine> model = _db.Cuisines.ToList();
        return View(model);
    }
}