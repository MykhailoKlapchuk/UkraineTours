using System;
using System.Collections.Generic;

namespace UkraineToursAPI.Dtos
{
    public class TourListDto
    {
        public int Id { get; set; }
        public string TourForm { get; set; }
        public string Name { get; set; }
        public string TourType { get; set; }
        public string SupportType { get; set; }
        public string City { get; set; }
             
        public int Price { get; set; }
        public int SupportPrice { get; set; }
        public int TransportationPrice { get; set; }
        public int AccommodationPrice { get; set; }
        public int FoodPrice { get; set; }
                
        public string CountryPart { get; set; }
        public string Region { get; set; }
        public string Settlements { get; set; }
        public string Magnets { get; set; }
                
        public bool AdultsOnly { get; set; }        
        public DateTime AvailableFrom { get; set; }
        public int Duration { get; set; }
        public string AccomType { get; set; }
        public string TransportType { get; set; }
        public string Description { get; set; }
        public string FoodPantion { get; set; }
        public string Photo { get; set; }
        public string OwnerName { get; set; }
        public string OwnerPhoneNumber { get; set; }
        public string OwnerEmail { get; set; }
        public ICollection<PhotoDto> Photos { get; set; }
    }
}
