using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UkraineToursAPI.Dtos;
using UkraineToursAPI.Interfaces;

namespace UkraineToursAPI.Controllers
{
    public class TourTypeController : BaseController
    {        
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public TourTypeController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        [HttpGet ("list")]        
        [AllowAnonymous]
        public async Task<IActionResult> GetTourTypes()
        {            
            var TourTypes = await uow.TourTypeRepository.GetTourTypesAsync();
            var TourTypesDto = mapper.Map<IEnumerable<KeyValuePairDto>>(TourTypes);
            return Ok(TourTypesDto);
        }
    }
}
