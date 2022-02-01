using System.Threading.Tasks;
using UkraineToursAPI.Data.Repo;
using UkraineToursAPI.Interfaces;

namespace UkraineToursAPI.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dc;

        public UnitOfWork(DataContext dc)
        {
            this.dc = dc;
        }
        public ICityRepository CityRepository => 
            new CityRepository(dc);

        public IUserRepository UserRepository =>         
            new UserRepository(dc);

        public ITourRepository TourRepository =>
            new TourRepository(dc);

        /*
public IFurnishingTypeRepository FurnishingTypeRepository =>         
new FurnishingTypeRepository(dc);

public IPropertyRepository PropertyRepository => 
new PropertyRepository(dc);*/

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}
