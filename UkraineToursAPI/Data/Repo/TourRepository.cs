using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UkraineToursAPI.Interfaces;
using UkraineToursAPI.Models;

namespace UkraineToursAPI.Data.Repo
{
    public class TourRepository: ITourRepository
    {
        private readonly DataContext dc;

        public TourRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public void AddTour(Tour tour)
        {
            dc.Tours.Add(tour);
        }

        public void DeleteTour(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tour>> GetToursAsync(int tourForm)
        {
            var tourFormEnum = ((TourForms)tourForm).ToString();
            var tours = await dc.Tours
            .Include(p => p.TourType)
            .Include(p => p.City)
            .Include(p => p.SupportType)
            .Include(p => p.Photos)
            .Where(p => p.TourForm == tourFormEnum)
            .ToListAsync();

            return tours;
        }

        public async Task<Tour> GetTourDetailAsync(int id)
        {
            var tours = await dc.Tours
            .Include(p => p.TourType)
            .Include(p => p.City)
            .Include(p => p.SupportType)
            .Include(p => p.Photos)
            .Include(p => p.User)
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();

            return tours;
        }

        public async Task<Tour> GetTourByIdAsync(int id)
        {
            var tours = await dc.Tours
            .Include(p => p.Photos)
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();

            return tours;
        }

        enum TourForms
        {
            Private = 1,
            Group = 2
        }
    }
}
