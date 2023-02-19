
using Microsoft.AspNetCore.Mvc;
using DataAccess.Repository.Products;

namespace eStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _db;
        public HomeController()
        {
            this._db = new ProductRepository();
        }
        public IActionResult Index()
        {
            var prods = this._db.GetList();
            return View(prods);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
