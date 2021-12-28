using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace WebAPI.Controllers
{
    [ApiController]
    public class CityController : ControllerBase
    {
        [Route("api/[controller]")]
        [HttpGet]
        public IEnumerable<string> GetCities()
        {            
            return new string[]{"Lviv", "Frankivsk", "Kyiv"};
        }

        // Post api/city/post --Post the data in JSON Format
        // [HttpPost("post")]
        // public async Task<IActionResult> AddCity(CityDto cityDto)
        // {
        //     var city = mapper.Map<City>(cityDto);
        //     city.LastUpdatedBy = 1;
        //     city.LastUpdatedOn = DateTime.Now;
        //     uow.CityRepository.AddCity(city);
        //     await uow.SaveAsync();
        //     return StatusCode(201);
        // }
        // [HttpPut("update/{id}")]
        // public async Task<IActionResult> UpdateCity(int id, CityDto cityDto)
        // {
        //     if(id != cityDto.Id)
        //         return BadRequest("Update not allowed");

        //     var cityFromDb = await uow.CityRepository.FindCity(id);

        //     if (cityFromDb == null)
        //         return BadRequest("Update not allowed");
            
        //     cityFromDb.LastUpdatedBy = 1;
        //     cityFromDb.LastUpdatedOn = DateTime.Now;
        //     mapper.Map(cityDto, cityFromDb);
        
        //     await uow.SaveAsync();
        //     return StatusCode(200);
        // }

        // [HttpPut("updateCityName/{id}")]
        // public async Task<IActionResult> UpdateCity(int id, CityUpdateDto cityDto)
        // {
        //     var cityFromDb = await uow.CityRepository.FindCity(id);
        //     cityFromDb.LastUpdatedBy = 1;
        //     cityFromDb.LastUpdatedOn = DateTime.Now;
        //     mapper.Map(cityDto, cityFromDb);
        //     await uow.SaveAsync();
        //     return StatusCode(200);
        // }

        // [HttpPatch("update/{id}")]
        // public async Task<IActionResult> UpdateCityPatch(int id, JsonPatchDocument<City> cityToPatch)
        // {
        //     var cityFromDb = await uow.CityRepository.FindCity(id);
        //     cityFromDb.LastUpdatedBy = 1;
        //     cityFromDb.LastUpdatedOn = DateTime.Now;

        //     cityToPatch.ApplyTo(cityFromDb, ModelState);
        //     await uow.SaveAsync();
        //     return StatusCode(200);
        // }

        // [HttpDelete("delete/{id}")]
        // public async Task<IActionResult> DeleteCity(int id)
        // {
        //     uow.CityRepository.DeleteCity(id);
        //     await uow.SaveAsync();
        //     return Ok(id);
        // }

    }
}
