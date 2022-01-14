using System.Collections.Generic;
using System.Threading.Tasks;
using UkraineToursAPI.Models;

namespace UkraineToursAPI.Interfaces
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        void AddCity(City city);
        void DeleteCity(int cityId);
        Task<City> FindCity(int id);
    }
}