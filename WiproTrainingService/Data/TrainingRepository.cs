using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WiproTrainingService.Data.Entities;

namespace WiproTrainingService.Data
{
    public class TrainingRepository : ITrainingRepository
    {
        public bool SaveChanges(Training training)
        {
            IList<Training> availableTrainings = GetAvailableTrainingsInStore().ToList();

            if (availableTrainings.Any())
            {
                var maxTrainingId = availableTrainings.Max(id => id.TrainingId);
                training.TrainingId = maxTrainingId + 1;
            }
            else
            {
                training.TrainingId = 1;
            }

            availableTrainings.Add(training);

            using (StreamWriter file = File.CreateText(@"Data\Assets\Training\Trainings.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, availableTrainings);
            }

            return true;
        }

        public IEnumerable<Training> GetTrainings()
        {
            return GetAvailableTrainingsInStore();
        }

        private IEnumerable<Training> GetAvailableTrainingsInStore(int id = 0)
        {
            string path;

            using (StreamReader r = new StreamReader(@"Data\Assets\Training\Trainings.json"))
            {
                path = r.ReadToEnd();// Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\Assets\Products.json");
            }

            var products = JsonConvert.DeserializeObject<IEnumerable<Training>>(path);

            if (id != 0)
            {
                return products.Where(x => x.TrainingId == id);
            }
            else
            {
                return products;
            }
        }
    }
}
