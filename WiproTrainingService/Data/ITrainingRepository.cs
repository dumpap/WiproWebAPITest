using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiproTrainingService.Data.Entities;

namespace WiproTrainingService.Data
{
    public interface ITrainingRepository
    {
        IEnumerable<Training> GetTrainings();

        bool SaveChanges(Training training);
    }
}
