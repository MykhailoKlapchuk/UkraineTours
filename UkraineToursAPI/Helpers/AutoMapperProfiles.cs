using AutoMapper;
using System.Linq;
using UkraineToursAPI.Dtos;
using UkraineToursAPI.Models;

namespace UkraineToursAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<City, CityUpdateDto>().ReverseMap();

            /*             CreateMap<Property, PropertyDto>().ReverseMap();

                        CreateMap<Photo, PhotoDto>().ReverseMap();
            */

            CreateMap<Tour, TourListDto>()
                .ForMember(d => d.City, opt => opt.MapFrom(src => src.City.Name))
                .ForMember(d => d.TourType, opt => opt.MapFrom(src => src.TourType.Name))
                .ForMember(d => d.SupportType, opt => opt.MapFrom(src => src.SupportType.Name))
                .ForMember(d => d.OwnerName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(d => d.OwnerPhoneNumber, opt => opt.MapFrom(src => src.User.PhoneNumber))
                .ForMember(d => d.OwnerEmail, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(d => d.Photo, opt => opt.MapFrom(src => src.Photos
                                .FirstOrDefault(p => p.IsPrimary).ImageUrl));


            CreateMap<TourListDto, Tour>()
                .ForMember(d => d.City, opt => opt.MapFrom(src => new City(){Name = src.City }))
                .ForMember(d => d.SupportType, opt => opt.MapFrom(src => new SupportType(){Name = src.SupportType }))
                .ForMember(d => d.TourType, opt => opt.MapFrom(src => new TourType(){Name = src.TourType }));


            CreateMap<SupportType, KeyValuePairDto>().ReverseMap();

            CreateMap<TourType, KeyValuePairDto>().ReverseMap();

        }
    }
}
