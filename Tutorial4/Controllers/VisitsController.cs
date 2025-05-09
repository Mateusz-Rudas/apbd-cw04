using Microsoft.AspNetCore.Mvc;
using Tutorial4.Models;

namespace Tutorial4.Controllers
{
    [ApiController]
    [Route("api/animals/{animalId}/[controller]")]
    public class VisitsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetVisits(int animalId)
        {
            var animal = Database.Animals.FirstOrDefault(a => a.Id == animalId);
            if (animal == null) return NotFound("Zwierze nie istnieje");
            return Ok(animal.Visits);
        }

        [HttpPost]
        public IActionResult AddVisit(int animalId, [FromBody] Visit visit)
        {
            var animal = Database.Animals.FirstOrDefault(a => a.Id == animalId);
            if (animal == null) return NotFound("Zwierze nie istnieje");

            visit.Id = animal.Visits.Any() ? animal.Visits.Max(v => v.Id) + 1 : 1;
            animal.Visits.Add(visit);
            return Ok(visit);
        }
    }
}