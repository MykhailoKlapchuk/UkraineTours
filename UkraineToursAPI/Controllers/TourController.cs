using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UkraineToursAPI.Dtos;
using UkraineToursAPI.Errors;
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

        [HttpGet("list/{tourForm}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTourList(int tourForm)
        {
            var tours = await uow.TourRepository.GetToursAsync(tourForm);
            var tourListDTO = mapper.Map<IEnumerable<TourListDto>>(tours);
            return Ok(tourListDTO);
        }

        [HttpGet("detail/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTourDetail(int id)
        {
            var tour = await uow.TourRepository.GetTourDetailAsync(id);
            if (tour == null)
            {
                var apiError = new ApiError();
                apiError.ErrorCode = NotFound().StatusCode;
                apiError.ErrorMessage = "There is no tour with this id";
                apiError.ErrorDetails = "This error appear when provided tour id does not exist";
                return NotFound(apiError);
            }

            var tourDTO = mapper.Map<TourListDto>(tour);
            return Ok(tourDTO);
        }
                
        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> AddTour(TourDto tourDto)
        {
            var tour = mapper.Map<Tour>(tourDto);
            var userId = GetUserId();
            tour.PostedBy = userId;
            tour.LastUpdatedBy = userId;
            uow.TourRepository.AddTour(tour);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPost("add/photo/{propId}")]
        [Authorize]
        public async Task<IActionResult> AddTourPhoto(IFormFile file, int propId)
        {
            var result = await photoService.UploadPhotoAsync(file);
            if (result.Error != null)
                return BadRequest(result.Error.Message);

            var tour = await uow.TourRepository.GetTourByIdAsync(propId);

            var photo = new Photo
            {
                ImageUrl = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };
            if (tour.Photos.Count == 0)
            {
                photo.IsPrimary = true;
                tour.Photo = photo.ImageUrl;
            }

            tour.Photos.Add(photo);
            await uow.SaveAsync();
            return StatusCode(201);
        }
    }
}
