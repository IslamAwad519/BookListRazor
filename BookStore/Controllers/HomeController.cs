using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            var books = new List<Book>();
            books.Add(new Book()
            { 
            Id = 0,
            AuthorId = 0,
              Title ="1223"
            });
            return View(books);
        }
        public ActionResult Search(string term)
        {
            var books = new List<Book>();
            books.Add(new Book()
            {
                Id = 0,
                AuthorId = 0,
                Title  = term
            }); 
            return View("Index", books);
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
