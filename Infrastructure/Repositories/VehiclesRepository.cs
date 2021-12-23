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

        public  override async Task<Vehicles> GetById(int id)
        {
                return await dbSet.FirstOrDefaultAsync(e=>e.Id == id);
        }

        public  async Task<Vehicles> GetByVinCode(string vincode)
        {
                return await dbSet.FirstOrDefaultAsync(e => e.VinCode == vincode);
        }

        public async Task<Vehicles> GetFullInfoByVinCode(string vincode)
        {

            return await dbSet.Include(e=>e.VehiclesPersons).ThenInclude(e=>e.Persons).FirstOrDefaultAsync(e => e.VinCode == vincode);
        }
    }
}
