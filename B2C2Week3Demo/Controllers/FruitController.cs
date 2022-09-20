using B2C2Week3Demo.Data;
using B2C2Week3Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace B2C2Week3Demo.Controllers
{
    public class FruitController : Controller
    {
        private readonly AppDbContext db;

        public FruitController(AppDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Fruit> objFruitList = db.Fruits;
            return View(objFruitList);
        }

        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE View
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Fruit fruit)
        {
            if (ModelState.IsValid)
            {
                db.Fruits.Add(fruit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //GET - DELETE View
        public IActionResult Delete (int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var fruit = db.Fruits.FirstOrDefault(f => f.Id == id);
            if (fruit == null)
            {
                return NotFound();
            }
            return View(fruit);
        }

        //POST - DELETE View
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var fruit = db.Fruits.Find(id);
            if (fruit == null)
            {
                return NotFound();
            }
            db.Fruits.Remove(fruit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
