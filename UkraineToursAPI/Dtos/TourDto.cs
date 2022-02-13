using System;

namespace UkraineToursAPI.Dtos
{
    public class TourDto
    {
        public string TourForm { get; set; }
        public string Name { get; set; }
        public int TourTypeId { get; set; }
        public int SupportTypeId { get; set; } 
        public int CityId { get; set; }
             
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
    }
}
