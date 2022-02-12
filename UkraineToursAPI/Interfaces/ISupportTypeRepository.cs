using System.Collections.Generic;
using System.Threading.Tasks;
using UkraineToursAPI.Models;

namespace UkraineToursAPI.Interfaces
{
    public interface ISupportTypeRepository
    {
        Task<IEnumerable<SupportType>> GetSupportTypesAsync();
    }
}
