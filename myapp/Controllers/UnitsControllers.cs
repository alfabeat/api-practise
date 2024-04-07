using Microsoft.AspNetCore.Mvc;
using myapp.Repositories;
using myapp.Models;
using myapp.Dtos;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Drawing;
using myapp;
namespace catalog.Controllers
{
    [ApiController]
    [Route("units")]
    public class UnitsController : ControllerBase
    {
        private readonly IUnitRepository repository;

        public UnitsController(IUnitRepository repository){
            this.repository = repository;
        }
        [HttpGet]
        public IEnumerable<UnitDto> GetUnits(){
            var units = repository.GetUnits().Select( unit => unit.AsDto());
            return units;
        }

        [HttpGet("{id}")]
        public ActionResult<UnitDto> GetUnit(Guid id){
            var unit = repository.GetUnit(id);
            if (unit is null)
            {
                return NotFound();
            }
            return unit.AsDto();
        }
        [HttpPost]
        public ActionResult<UnitDto> CreateUnit(CreateUnitDto unitDto){
            Unit unit = new(){
                Id = Guid.NewGuid(),
                Name = unitDto.Name,
                Points = unitDto.Points,
                CreatedDate = DateTimeOffset.Now
            };
            repository.CreateUnit(unit);

            return CreatedAtAction(nameof(GetUnit), new {id = unit.Id}, unit.AsDto());
        }
        [HttpPut("{id}")]
          public ActionResult UpdateUnit(Guid id, UpdateUnitDto unitDto){
         var existingUnit = repository.GetUnit(id);
         if(existingUnit is null){
            return NotFound();
         }
         Unit updatedUnit = existingUnit with{
            Name = unitDto.Name,
            Points = unitDto.Points
         };
            repository.UpdateUnit(updatedUnit);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleateUnit(Guid id){
         var existingUnit = repository.GetUnit(id);
         if(existingUnit is null){
            return NotFound();
         }
     
            repository.DeleateUnit(id);

            return NoContent();
        }

    }
}