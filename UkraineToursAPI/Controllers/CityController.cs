using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UkraineToursAPI.Data;
using UkraineToursAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly DataContext dataContext;

        public CityController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await dataContext.Cities.ToListAsync();

            return Ok(cities);
        }
        
         [HttpPost("add/{cityName}")]
         public async Task<IActionResult> AddCity(string cityName)
         {
             var city = new City(){Name = cityName};
             await dataContext.Cities.AddAsync(city);
             await dataContext.SaveChangesAsync();

             return Ok(city);
         }

         [HttpDelete("delete/{id}")]
         public async Task<IActionResult> DeleteCity(int id)
         {
             var city = await dataContext.Cities.FindAsync(id);
             dataContext.Cities.Remove(city);
             await dataContext.SaveChangesAsync();

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
