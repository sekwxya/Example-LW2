using _2LR.Data;
using _2LR.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace _2LR.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _db;

        public ProductController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Products.ToList());
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _db.Add(product);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Clear()
        {
            _db.RemoveRange(_db.Products.ToList());
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id) 
        {
            if (id != null)
            {
                var product = new Product { Id = id.Value };
                _db.Entry(product).State = EntityState.Deleted;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                var product = await _db.Products.FirstOrDefaultAsync(p=>p.Id == id);
                if (product != null) return View(product);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            _db.Products.Update(product);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Read(int? id)
        {
            if (id != null)
            {
                var product = _db.Products.FirstOrDefault(p=>p.Id == id);
                if(product != null) return View(product);
            }
            return NotFound();
        }
    }
}
