using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UkraineToursAPI.Interfaces;
using UkraineToursAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly IUnitOfWork uow;

        public CityController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        
        // GET api/city
        [HttpGet ("cities")]        
        [AllowAnonymous]
        public async Task<IActionResult> GetCities()
        {
            var cities = await uow.CityRepository.GetCitiesAsync();

            return Ok(cities);
        }
        
         [HttpPost("add")]
         public async Task<IActionResult> AddCity(City city)
         {
             uow.CityRepository.AddCity(city);
             await uow.SaveAsync();

             return StatusCode(201);
         }

         [HttpDelete("delete/{id}")]
         public async Task<IActionResult> DeleteCity(int id)
         {
             uow.CityRepository.DeleteCity(id);
             await uow.SaveAsync();

             return Ok(id);
         }
         /*
         [HttpPut("update/{id}")]
         public async Task<IActionResult> UpdateCity(int id, CityDto cityDto)
         {
             if(id != cityDto.Id)
                 return BadRequest("Update not allowed");

             var cityFromDb = await uow.CityRepository.FindCity(id);

             if (cityFromDb == null)
                 return BadRequest("Update not allowed");
            
             cityFromDb.LastUpdatedBy = 1;
             cityFromDb.LastUpdatedOn = DateTime.Now;
             mapper.Map(cityDto, cityFromDb);
        
             await uow.SaveAsync();
             return StatusCode(200);
         }

         [HttpPut("updateCityName/{id}")]
         public async Task<IActionResult> UpdateCity(int id, CityUpdateDto cityDto)
         {
             var cityFromDb = await uow.CityRepository.FindCity(id);
             cityFromDb.LastUpdatedBy = 1;
             cityFromDb.LastUpdatedOn = DateTime.Now;
             mapper.Map(cityDto, cityFromDb);
             await uow.SaveAsync();
             return StatusCode(200);
         }

         [HttpPatch("update/{id}")]
         public async Task<IActionResult> UpdateCityPatch(int id, JsonPatchDocument<City> cityToPatch)
         {
             var cityFromDb = await uow.CityRepository.FindCity(id);
             cityFromDb.LastUpdatedBy = 1;
             cityFromDb.LastUpdatedOn = DateTime.Now;

             cityToPatch.ApplyTo(cityFromDb, ModelState);
             await uow.SaveAsync();
             return StatusCode(200);
         }
         }*/
        

    }
}
