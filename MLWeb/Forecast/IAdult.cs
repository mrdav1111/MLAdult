using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLWeb.Forecast
{
    public interface IAdult
    {
         Task<AdultPrediction> Predecir(string path, AdultData adult);
    }
}
