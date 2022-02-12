using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UkraineToursAPI.Interfaces;
using UkraineToursAPI.Models;

namespace UkraineToursAPI.Data.Repo
{
    public class SupportTypeRepository : ISupportTypeRepository
    {
        private readonly DataContext dc;

        public SupportTypeRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public async Task<IEnumerable<SupportType>> GetSupportTypesAsync()
        {
            return await dc.SupportTypes.ToListAsync();
        }
    }
}
