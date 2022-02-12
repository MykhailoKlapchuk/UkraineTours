using System.Threading.Tasks;

namespace UkraineToursAPI.Interfaces
{
    public interface IUnitOfWork
    {
        ICityRepository CityRepository {get; }

        IUserRepository UserRepository {get; }

        ITourRepository TourRepository {get; }

        ISupportTypeRepository SupportTypeRepository {get; }

        ITourTypeRepository TourTypeRepository {get; }

        Task<bool> SaveAsync();
    }
}