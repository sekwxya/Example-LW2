using _2LR.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace _2LR.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> _products = new List<Product>();

        public IActionResult Index()
        {
            return View(_products);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                _products.Add(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Clear()
        {
            _products.Clear();
            return RedirectToAction("Index");
        }
    }

}
