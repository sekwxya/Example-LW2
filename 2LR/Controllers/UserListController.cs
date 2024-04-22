using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using _2LR.Data;
using Microsoft.EntityFrameworkCore;

namespace _2LR.Controllers
{
    public class UserListController : Controller
    {
        private readonly AppDbContext _db;

        public UserListController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var users = _db.Users.Include(u => u.Role).ToList();
            return View(users);
        }

    }
}
