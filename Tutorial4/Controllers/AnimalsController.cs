using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using Tutorial4.Models;

namespace Tutorial4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAnimals()
        {
            return Ok(Database.Animals);
        }

        [HttpGet("{id}")]
        public IActionResult GetAnimal(int id)
        {
            var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null) return NotFound("Nie znaleziono zwierzecia");
            return Ok(animal);
        }

        [HttpGet("search")]
        public IActionResult SearchByName([FromQuery] string name)
        {
            var animals = Database.Animals.Where(a => a.Name.ToLower().Contains(name.ToLower())).ToList();
            return Ok(animals);
        }

        [HttpPost]
        public IActionResult AddAnimal([FromBody] Animal animal)
        {
            animal.Id = Database.Animals.Max(a => a.Id) + 1;
            Database.Animals.Add(animal);
            return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAnimal(int id, [FromBody] Animal updated)
        {
            var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null) return NotFound();

            animal.Name = updated.Name;
            animal.Category = updated.Category;
            animal.Weight = updated.Weight;
            animal.FurColor = updated.FurColor;

            return Ok(animal);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null) return NotFound();
            Database.Animals.Remove(animal);
            return NoContent();
        }
    }
}
