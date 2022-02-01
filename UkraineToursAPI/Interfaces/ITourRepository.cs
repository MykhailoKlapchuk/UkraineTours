using System.Collections.Generic;
using System.Threading.Tasks;
using UkraineToursAPI.Models;

namespace UkraineToursAPI.Interfaces
{
    public interface ITourRepository
    {        
        Task<IEnumerable<Tour>> GetToursAsync(int tourForm);
        Task<Tour> GetTourDetailAsync(int id);
        Task<Tour> GetTourByIdAsync(int id);
        void AddTour(Tour Tour);
        void DeleteTour(int id);
    }
}
