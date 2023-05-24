using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace eStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _db;
        public HomeController(IProductRepository db) => _db = db;


        public IActionResult Index()
        {
            var prods = _db.GetList();
            return View(prods);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
