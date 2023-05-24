using BusinessObject.Objects;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace eStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _db;
        public ProductController(IProductRepository db) => _db = db;

        public IActionResult Index() => View();

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _db.InsertProduct(product);
                return Redirect("/");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var product = _db.GetProduct(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                _db.DeleteProduct(id.Value);
            }
            return Redirect("/");
        }

        public IActionResult View(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _db.GetProduct(id.Value);
            return View(product);
        }

        public IActionResult Update(int id)
        {
            var product = _db.GetProduct(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(int? id, Product prod)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                _db.UpdateProduct(prod);
            }
            return Redirect("/");
        }
    }
}