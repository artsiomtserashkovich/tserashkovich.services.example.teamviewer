using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Football.TeamViewer.Domain;

namespace Football.TeamViewer.Application.Players
{
    public interface IPlayerRepository
    {
        Task<IReadOnlyCollection<Player>> GetByManagerId(Guid managerId);
        
        Task<bool> Create(Guid managerId, Player player);
    }
}