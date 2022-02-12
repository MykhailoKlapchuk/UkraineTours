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

        public ISupportTypeRepository SupportTypeRepository =>
        new SupportTypeRepository(dc);

        public ITourTypeRepository TourTypeRepository =>
        new TourTypeRepository(dc);

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}
