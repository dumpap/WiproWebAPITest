using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WiproTrainingService.Data;
using WiproTrainingService.Data.Entities;

namespace WiproTrainingService.Controllers
{
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingRepository _trainingRepository;

        public TrainingController(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }

        [Route("api/Trainings")]
        [HttpGet]
        public IActionResult GetTrainings()
        {
            try
            {
                var results = _trainingRepository.GetTrainings();
                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Some issue in server");
            }

        }

        [Route("api/Trainings/Add")]
        [HttpPost]
        public IActionResult AddTraining(Training training)
        {
            if (_trainingRepository.SaveChanges(training))
            {
                return Created($"/api/Trainings/{training.TrainingId}", training);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}