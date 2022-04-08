using CinemaCentre.Controllors;
using CinemaCentre.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaCentre.Controllers
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
            var rows = DatabaseConnector.GetRows("select * from product");


            List<string> names = new List<string>();

            foreach (var row in rows)
            {

                names.Add(row["naam"].ToString());
            }

            return View(names);
        }

        [Route("detail/{id}")]
        public IActionResult Detail(string id)
        {
            ViewData["id"] = id;

            return View();
        }

        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("Show-all")]
        public IActionResult ShowAll()
        {
            return View();
        }

        [Route("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [Route("contact")]
        public IActionResult ContactPost(Person person)
        {
            if (ModelState.IsValid)
            {
                //opslaan in database
                return RedirectToAction("Succes",person);
               
            }
            return View("contact", person);
        }
       
        
        [Route("Succes")]
        public IActionResult Succes(Person person)
        
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public List<Product> GetAllProducts()
        {
            var rows = DatabaseConnector.GetRows("select * from product");


            List<Product> product = new List<Product>();

            foreach (var row in rows)
            {

                product.Add(row["naam"].ToString());
            }

            return (product);
        }
    }
}

