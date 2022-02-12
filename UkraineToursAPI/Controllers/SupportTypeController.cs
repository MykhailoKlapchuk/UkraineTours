using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UkraineToursAPI.Dtos;
using UkraineToursAPI.Interfaces;

namespace UkraineToursAPI.Controllers
{
    public class SupportTypeController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public SupportTypeController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        [HttpGet ("list")]        
        [AllowAnonymous]
        public async Task<IActionResult> GetSupportTypes()
        {            
            var supportTypes = await uow.SupportTypeRepository.GetSupportTypesAsync();
            var supportTypesDto = mapper.Map<IEnumerable<KeyValuePairDto>>(supportTypes);
            return Ok(supportTypesDto);
        }
    }
}
