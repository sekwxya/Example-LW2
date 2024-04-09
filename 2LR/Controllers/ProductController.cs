using _2LR.Data;
using _2LR.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace _2LR.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext dbContext;

        public ProductController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("http://localhost:5203/product");
            var jsonString = await response.Content.ReadAsStringAsync();
            var ProductsList = JsonConvert.DeserializeObject<List<Product>>(jsonString);
            return View(ProductsList);
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
                dbContext.Add(product);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Clear()
        {
            dbContext.RemoveRange(dbContext.Products.ToList());
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
