using System.Linq;
using ToDoList.Models;

namespace ToDoList.Controllers;

public class CategoriesController : Controller
{
    private readonly ToDoListContext _db;

    public CategoriesController(ToDoListContext db)
    {
        _db = db;
    }

    public ActionResult Index()
    {
        List<Category> model = _db.Categories.ToList();
        return View(model);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Category category)
    {
        _db.Categories.Add(category);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
        Category category = _db.Categories
            .Include(cat => cat.Items)
            .FirstOrDefault(cat => cat.CategoryId == id);
        return View(category);
    }

    public ActionResult Edit(int id)
    {
        Category category = _db.Categories.FirstOrDefault(cat => cat.CategoryId == id);
        return View(category);
    }

    [HttpPost]
    public ActionResult Edit(Category category)
    {
        _db.Categories.Update(category);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        Category category = _db.Categories.FirstOrDefault(cat => cat.CategoryId == id);
        return View(category);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        Category category = _db.Categories.FirstOrDefault(cat => cat.CategoryId == id);
        _db.Categories.Remove(category);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}