using KittyCatMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KittyCatMVC.Controllers
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
            return View();
        }

        [HttpGet]
        public IActionResult KCPage()
        {
            KittyCat model = new();

            model.KittyValue = 3;
            model.CatValue = 5;

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult KCPage(KittyCat kittycat)
        {
            List<string> kcItems = new();

            bool kitty;
            bool cat;

            for (int i = 1; i <= 100; i++)
            {
                kitty = (i % kittycat.KittyValue == 0);
                cat = (i % kittycat.CatValue == 0);

                if (kitty && cat)
                {
                    kcItems.Add("KittyCat");
                }
                else if (kitty)
                {
                    kcItems.Add("Kitty");
                }
                else if (cat)
                {
                    kcItems.Add("Cat");
                }
                else
                {
                    kcItems.Add(i.ToString());
                }
            }

            kittycat.Result = kcItems;

            return View(kittycat);
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