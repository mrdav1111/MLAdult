using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Models;
using Microsoft.ML.Runtime.Api;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;

namespace Trainer
{
    class Program
    {
        static readonly string _dataPath = Path.Combine(Environment.CurrentDirectory, "Datos", "adult-line-data.csv");
        static readonly string _testDataPath = Path.Combine(Environment.CurrentDirectory, "Datos", "adult-line-test.csv");
        static readonly string _modelpath = Path.Combine(Environment.CurrentDirectory, "Datos", "Model.zip");

        static async Task Main(string[] args)
        {
            var model = await Train();
            Evaluate(model);
        }

        public static async Task<PredictionModel<AdultData, AdultPrediction>> Train()
        {
            var pipeline = new LearningPipeline();

            pipeline.Add(new TextLoader(_dataPath).CreateFrom<AdultData>(separator: ';', useHeader: true));


            pipeline.Add(new TextFeaturizer("Features", "workClass", "education", "maritalStatus", "occupation", "relationship", "race", "sex", "nativeCountry"));
            pipeline.Add(new FastTreeBinaryClassifier());

            PredictionModel<AdultData, AdultPrediction> model = pipeline.Train<AdultData, AdultPrediction>();

            await model.WriteAsync(_modelpath);



            return model;
        }

        public static void Evaluate(PredictionModel<AdultData, AdultPrediction> model)
        {
            var testData = new TextLoader(_testDataPath).CreateFrom<AdultData>(separator: ';', useHeader: true);
            var evaluator = new BinaryClassificationEvaluator();
            BinaryClassificationMetrics metrics = evaluator.Evaluate(model, testData);
            Console.WriteLine();
            Console.WriteLine("PredictionModel quality metrics evaluation");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Accuracy: {metrics.Accuracy:P2}");
            Console.WriteLine($"Auc: {metrics.Auc:P2}");
            Console.WriteLine($"F1Score: {metrics.F1Score:P2}");
            Console.ReadLine();

            IEnumerable<AdultData> adults = new[]
            {
                new AdultData()
                {
                age = 39,
                workClass = "State-gov",
                fnlwgt = 77516,
                education = "Bachelors",
                relationship = "Not-in-family",
                race = "White",
                sex = "Male",
                capitalGain = 2174,
                capitalLoss = 0,
                hoursPerWeek = 40,
                maritalStatus = "Never-married",
                occupation = "Adm-clerical",
                nativeCountry = "United-States"
                },

                new AdultData()
                {
                age = 20,
                workClass = "Self-emp-inc",
                fnlwgt = 166459,
                education = "Prof-school",
                relationship = "Husband",
                race = "White",
                sex = "Male",
                capitalGain = 99999,
                capitalLoss = 0,
                hoursPerWeek = 60,
                maritalStatus = "Married-civ-spouse",
                occupation = "Prof-specialty",
                nativeCountry = "United-States"
                },

                new AdultData()
                {
               age = 40,
                workClass = "Self-emp-inc",
                fnlwgt = 166459,
                education = "Prof-school",
                relationship = "Husband",
                race = "White",
                sex = "Male",
                capitalGain = 99999,
                capitalLoss = 0,
                hoursPerWeek = 60,
                maritalStatus = "Married-civ-spouse",
                occupation = "Prof-specialty",
                nativeCountry = "United-States" }

            };

            var forecast = model.Predict(adults);

            foreach (var item in forecast)
            {
                Console.WriteLine(item.esMayorA50);
            }
            
            Console.ReadLine();
        }
    }
}
