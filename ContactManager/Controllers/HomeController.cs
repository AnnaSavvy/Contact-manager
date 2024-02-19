using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactManager.Models;

namespace ContactManager.Controllers
{
    public class HomeController : Controller
    {
        private AssignmentContext context { get; set; }

        public HomeController(AssignmentContext ctx) => context = ctx;

        public IActionResult Index()
        {
            var contacts = context.Contacts
                .Include(m => m.Category)
                .OrderBy(m => m.FirstName)
                .ToList();

            return View(contacts);
        }
    }
}