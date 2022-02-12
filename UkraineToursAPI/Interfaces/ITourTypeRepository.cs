using System.Collections.Generic;
using System.Threading.Tasks;
using UkraineToursAPI.Models;

namespace UkraineToursAPI.Interfaces
{
    public interface ITourTypeRepository
    {        
        Task<IEnumerable<TourType>> GetTourTypesAsync(); 
    }
}
