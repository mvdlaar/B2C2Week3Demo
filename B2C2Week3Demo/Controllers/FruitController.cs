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
    }
}
