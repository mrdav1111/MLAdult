using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MLWeb.Forecast;
using MLWeb.Models;

namespace MLWeb.Controllers
{
    public class HomeController : Controller
    {

        static readonly string _modelpath = Path.Combine(Environment.CurrentDirectory, "MLModel", "Model.zip");
        private IAdult _adult;

        public HomeController(IAdult adult)
        {
            this._adult = adult;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> EsMayorA50([FromQuery] int edad,
            [FromQuery] string workClass,
            [FromQuery] int fnlwgt,
            [FromQuery] string educacion,
            [FromQuery] string estadoCivil,
            [FromQuery] string ocupacion,
            [FromQuery] string relacion,
            [FromQuery] string raza,
            [FromQuery] string sexo,
            [FromQuery] int gananciaCapital,
            [FromQuery] int perdidaCapital,
            [FromQuery] int horasPorSemana,
            [FromQuery] string paisNativo)
        {
            AdultData adultData = new AdultData()
            {
                age = edad,
                workClass = workClass,
                fnlwgt = fnlwgt,
                education = educacion,
                relationship = relacion,
                race = raza,
                sex = sexo,
                capitalGain = gananciaCapital,
                capitalLoss = perdidaCapital,
                hoursPerWeek = horasPorSemana,
                maritalStatus = estadoCivil,
                occupation = ocupacion,
                nativeCountry = paisNativo
            };

            var prediccion = await _adult.Predecir(_modelpath, adultData);
            return PartialView(prediccion);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
