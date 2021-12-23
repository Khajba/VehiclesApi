using Infrastructure.Repositories;
using System.Threading.Tasks;

namespace Infrastructure.Context.UnitOfWork
{
    public interface IUnitOfWork
    {
        IVehiclesRepository Vehicles { get; }
        IPersonsRepository Persons { get; }
        IVehiclesPersonsRepository VehiclesPersons { get; }
        Task CompleteAsync();
        void Dispose();
    }
}
