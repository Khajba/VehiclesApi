using Infrastructure.Entities;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IVehiclesRepository : IGenericRepository<Vehicles>
    {
        Task<Vehicles> GetByVinCode(string vincode);

        Task<Vehicles> GetFullInfoByVinCode(string vincode);
    }
}
