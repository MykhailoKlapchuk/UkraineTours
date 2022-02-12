using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UkraineToursAPI.Interfaces;
using UkraineToursAPI.Models;

namespace UkraineToursAPI.Data.Repo
{
    public class TourTypeRepository : ITourTypeRepository
    {
        private readonly DataContext dc;

        public TourTypeRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public async Task<IEnumerable<TourType>> GetTourTypesAsync()
        {
            return await dc.TourTypes.ToListAsync();
        }
    }
}
