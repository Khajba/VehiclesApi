using Infrastructure.Context;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;



namespace Infrastructure.Repositories
{
    public class VehiclesPersonsRepository : GenericRepository<VehiclesPersons>, IVehiclesPersonsRepository
    {
        public VehiclesPersonsRepository(VehiclesContext context, ILogger logger) : base(context, logger)
        {
        }
        public override async Task<IEnumerable<VehiclesPersons>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(VehiclesRepository));
                return new List<VehiclesPersons>();
            }
        }
       
    }
}
