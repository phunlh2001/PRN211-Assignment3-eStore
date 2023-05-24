
using BusinessObject.Objects;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace eStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _db;
        public OrderController(IOrderRepository db) => _db = db;


        public IActionResult Index()
        {
            var list = _db.GetList();
            return View(list);
        }
        public IActionResult Create(string name, int price)
        {
            TempData["ProductName"] = name;
            TempData["Price"] = price;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                _db.InsertOrder(order);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult CancelOrder(int id)
        {
            _db.DeleteOrder(id);
            return RedirectToAction("Index");
        }
    }
}