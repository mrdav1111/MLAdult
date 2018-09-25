using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLWeb.Forecast
{
    
    public class Adult : IAdult
    {
        
        static async Task<PredictionModel<AdultData, AdultPrediction>> crearMotorDePrediccionAsync(string modelPath)
        {
            PredictionModel<AdultData, AdultPrediction> model = await PredictionModel.ReadAsync<AdultData, AdultPrediction>(modelPath);

            return model;
        }

        public async Task<AdultPrediction> Predecir(string path, AdultData adult)
        {
            var motorDePrediccion = await crearMotorDePrediccionAsync(path);

            return motorDePrediccion.Predict(adult);
        }
    }
}
