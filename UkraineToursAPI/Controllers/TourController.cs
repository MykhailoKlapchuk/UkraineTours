using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UkraineToursAPI.Interfaces;
using UkraineToursAPI.Models;

namespace UkraineToursAPI.Controllers
{
    public class TourController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly IPhotoService photoService;

        public TourController(IUnitOfWork uow,
        IMapper mapper,
        IPhotoService photoService)
        {
            this.photoService = photoService;
            this.uow = uow;
            this.mapper = mapper;
        }

        //Tour/list/1
        [HttpGet("list/{tourForm}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTourList(int tourForm)
        {
            var Tours = await uow.TourRepository.GetToursAsync(tourForm);
            //var TourListDTO = mapper.Map<IEnumerable<TourListDto>>(Tours);
            return Ok(Tours); // TourListDTO
        }

        //Tour/detail/1
        [HttpGet("detail/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTourDetail(int id)
        {
            var Tour = await uow.TourRepository.GetTourDetailAsync(id);
            //var TourDTO = mapper.Map<TourDetailDto>(Tour);
            return Ok(Tour); //TourDTO
        }

/*        //Tour/add
        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> AddTour(TourDto TourDto)
        {
            var Tour = mapper.Map<Tour>(TourDto);
            var userId = GetUserId();
            Tour.PostedBy = userId;
            Tour.LastUpdatedBy = userId;
            uow.TourRepository.AddTour(Tour);
            await uow.SaveAsync();
            return StatusCode(201);
        }*/

        //Tour/add/photo/1
        [HttpPost("add/photo/{propId}")]
        [Authorize]
        public async Task<IActionResult> AddTourPhoto(IFormFile file, int propId)
        {
            var result = await photoService.UploadPhotoAsync(file);
            if (result.Error != null)
                return BadRequest(result.Error.Message);

            var Tour = await uow.TourRepository.GetTourByIdAsync(propId);

            var photo = new Photo
            {
                ImageUrl = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };
            if (Tour.Photos.Count == 0)
            {
                photo.IsPrimary = true;
            }

            Tour.Photos.Add(photo);
            await uow.SaveAsync();
            return StatusCode(201);
        }
    }
}
