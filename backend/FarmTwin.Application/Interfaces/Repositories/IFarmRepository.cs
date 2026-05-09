using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FarmTwin.Domain.Entities;

namespace FarmTwin.Application.Interfaces.Repositories;

public interface IFarmRepository : IRepository<Farm>
{
    Task<IEnumerable<Farm>> GetFarmsByOwnerIdAsync(string ownerId);
}
