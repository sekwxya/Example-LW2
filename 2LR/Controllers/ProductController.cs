using _2LR.Data;
using _2LR.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace _2LR.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext dbContext;

        public ProductController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View(dbContext.Products.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product != null) return View(product);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int? id) 
        {
                var product = new Product { Id = id.Value };
                dbContext.Entry(product).State = EntityState.Deleted;
                await dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                var product = await dbContext.Products.FirstOrDefaultAsync(p=>p.Id == id);
                if (product != null) return View(product);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            dbContext.Products.Update(product);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Read(int? id)
        {
            if (id != null)
            {
                var product = dbContext.Products.FirstOrDefault(p=>p.Id == id);
                if(product != null) return View(product);
            }
            return NotFound();
        }
    }
}
