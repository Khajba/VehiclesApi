using Infrastructure.Context;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class VehiclesRepository : GenericRepository<Vehicles>, IVehiclesRepository
    {
        public VehiclesRepository(VehiclesContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<Vehicles>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(VehiclesRepository));
                return new List<Vehicles>();
            }
        }

        public override async Task<Vehicles> GetById(int id)
        {
            try
            {
                return await dbSet.FirstOrDefaultAsync(e=>e.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(VehiclesRepository));
                return new Vehicles();
            }
        }
    }
}
