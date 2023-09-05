using CrudNet7.Data;
using CrudNet7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CrudNet7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contacts.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create() 
        { 
            return View();  
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contact contact)
        {
            if(ModelState.IsValid)
            {
                _context.Contacts.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));   
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var contac = _context.Contacts.Find(id);

            if(contac is null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(contac);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Update(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var contac = _context.Contacts.Find(id);

            if (contac is null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(contac);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contac = _context.Contacts.Find(id);

            if (contac is null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(contac);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);

            if(contact is null)
            {
                return View();
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); 
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}