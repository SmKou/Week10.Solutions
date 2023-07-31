using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using ToDoList.Models;

namespace ToDoList.Controllers;

public class ItemsController : Controller
{
    private readonly ToDoListContext _db;

    public ItemsController(ToDoListContext db)
    {
        _db = db;
    }

    public ActionResult Index()
    {
        List<Item> model = _db.Items
            .Include(item => item.Category)
            .ToList();
        return View(model);
    }

    public ActionResult Create()
    {
        ViewBag.PageTitle = "Add New Item";
        ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
        return View();
    }

    [HttpPost]
    public ActionResult Create(Item item)
    {
        if (item.CategoryId == 0)
            return RedirectToAction("Create");
        _db.Items.Add(item);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
        Item item = _db.Items
            .Include(itm => itm.Category)
            .FirstOrDefault(itm => itm.ItemId == id);
        return View(item);
    }

    public ActionResult Edit(int id)
    {
        Item item = _db.Items.FirstOrDefault(itm => itm.ItemId == id);
        ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
        ViewBag.PageTitle = "Edit Item";
        return View(item);
    }

    [HttpPost]
    public ActionResult Edit(Item item)
    {
        _db.Items.Update(item);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        Item item = _db.Items.FirstOrDefault(itm => itm.ItemId == id);
        return View(item);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        Item item = _db.Items.FirstOrDefault(itm => itm.ItemId == id);
        _db.Items.Remove(item);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}