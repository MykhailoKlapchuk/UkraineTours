using System.Threading.Tasks;

namespace UkraineToursAPI.Interfaces
{
    public interface IUnitOfWork
    {
        ICityRepository CityRepository {get; }

        IUserRepository UserRepository {get; }

        ITourRepository TourRepository {get; }

        //IFurnishingTypeRepository FurnishingTypeRepository {get; }

        //IPropertyTypeRepository PropertyTypeRepository {get; }

        Task<bool> SaveAsync();
    }
}