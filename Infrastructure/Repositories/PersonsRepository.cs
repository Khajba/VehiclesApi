using Infrastructure.Context;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PersonsRepository : GenericRepository<Persons>, IPersonsRepository
    {

        public PersonsRepository(VehiclesContext context, ILogger logger) : base(context, logger)
        {
        }
        public override async Task<Persons> GetById(int id)
        {
            try
            {
                return await dbSet.FirstOrDefaultAsync(e => e.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(PersonsRepository));
                return new Persons();
            }
        }

        public async Task<Persons> GetByPersonNumber(string PersonNumber)
        {
            try
            {
                return await dbSet.FirstOrDefaultAsync(p => p.PersonNumber == PersonNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(PersonsRepository));
                return new Persons();
            }
        }
    }
}
