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
            var allMovies = GetAllMovies();

            return View(allMovies);
        }

        [Route("detail/{id}")]
        public IActionResult Detail(string id)
        {
            ViewData["id"] = id;

            return View();
        }

        [Route("Tijden")]
        public IActionResult Tijden()
        {
            return View();
        }

        [Route("Movie")]
        public IActionResult Movie()
        {
            return View();

        }

        [Route("Moviedetails")]
        public IActionResult Moviedetails()
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
                DatabaseConnector.SavePerson(person);

                //opslaan in database
                return RedirectToAction("Succes", person);

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

        public List<Movie> GetAllMovies()
        {
            var rows = DatabaseConnector.GetRows("select * from movie");


            List<Movie> product = new List<Movie>();

            foreach (var row in rows)
            {
                Movie m = new Movie();

                m.Afbeelding = row["afbeelding"].ToString();
                m.Titel = row["titel"].ToString();
                m.Beschrijving = row["beschrijving"].ToString();
                m.Id = Convert.ToInt32(row["id"]);

                product.Add(m);
            }

            return (product);
        }
    }
}

