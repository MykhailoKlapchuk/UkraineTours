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
        public void AddTour(Tour Tour)
        {
            dc.Tours.Add(Tour);
        }

        public void DeleteTour(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tour>> GetToursAsync(int tourForm)
        {
            var tourFormEnum = ((TourForms)tourForm).ToString();
            var Tours = await dc.Tours
            .Include(p => p.TourType)
            .Include(p => p.City)
            .Include(p => p.SupportType)
            .Include(p => p.Photos)
            .Where(p => p.TourForm == tourFormEnum)
            .ToListAsync();

            return Tours;
        }

        public async Task<Tour> GetTourDetailAsync(int id)
        {
            var Tours = await dc.Tours
            .Include(p => p.TourType)
            .Include(p => p.City)
            .Include(p => p.SupportType)
            .Include(p => p.Photos)
            .Where(p => p.Id == id)
            .FirstAsync();

            return Tours;
        }

        public async Task<Tour> GetTourByIdAsync(int id)
        {
            var Tours = await dc.Tours
            .Include(p => p.Photos)
            .Where(p => p.Id == id)
            .FirstAsync();

            return Tours;
        }

        enum TourForms
        {
            Private = 0,
            Group = 1
        }


    }
}
