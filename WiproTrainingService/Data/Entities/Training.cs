using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WiproTrainingService.Data.Entities
{
    public class Training
    {
        public int TrainingId { get; set; }
        public string TrainingName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
