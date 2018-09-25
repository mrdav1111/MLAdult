using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MLWeb.Forecast;

namespace MLWeb.Controllers
{
 
    [Route("api/[controller]")]
    [ApiController]
    public class PrediccionController : ControllerBase
    {
        static readonly string _modelpath = Path.Combine(Environment.CurrentDirectory, "MLModel", "Model.zip");
        private IAdult _adult;

        public PrediccionController(IAdult adult)
        {
            this._adult = adult;
        }

        [HttpGet()]
        public async Task<IActionResult> GetPrediccion([FromQuery] int edad,
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


            return Ok(prediccion);
        }
    }
}