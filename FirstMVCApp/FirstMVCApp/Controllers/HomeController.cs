using FirstMVCApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMVCApp.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// This 'gets' the index and will return the view
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// this will post and redirect the user to the results page with the new variable names
        /// </summary>
        /// <param name="startYear"></param>
        /// <param name="endYear"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(int startYear, int endYear)
        {
            return RedirectToAction("Results", new { NewStartYear = startYear, newEndYear = endYear });
        }

        /// <summary>
        /// the new variable names will return the view based on the user's input of the years
        /// </summary>
        /// <param name="newStartYear"></param>
        /// <param name="newEndYear"></param>
        /// <returns></returns>

        public IActionResult Results(int newStartYear, int newEndYear)
        {

            Person person = new Person();

            return View(Person.GetPersons(newStartYear, newEndYear));
        }

    }
}
