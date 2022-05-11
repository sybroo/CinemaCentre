using CinemaCentre.Controllors;
using CinemaCentre.Database;
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
        public List<Movie> GetAllProducts()
        {
            var rows = DatabaseConnector.GetRows("select * from product");


            List<Movie> product = new List<Movie>();

            foreach (var row in rows)
            {
                Movie m = new Movie();

                m.Afbeelding = row["afbeedling"].ToString();
                m.Titel = row["Titel"].ToString();
                m.Beschrijving = row["Beschrijving"].ToString();
                m.Id = Convert.ToInt32(row["id"]);

                product.Add(m);
            }

            return (product);
        }
    }
}

