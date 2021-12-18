using Infrastructure.Repositories;
using System.Threading.Tasks;

namespace Infrastructure.Context.UnitOfWork
{
    public interface IUnitOfWork
    {
        IVehiclesRepository Vehicles { get; }
        Task CompleteAsync();
        void Dispose();
    }
}
