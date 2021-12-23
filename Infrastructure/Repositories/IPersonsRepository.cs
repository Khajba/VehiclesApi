using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IPersonsRepository : IGenericRepository<Persons>
    {
        Task<Persons> GetByPersonNumber(string PersonNumber);
    }
}
