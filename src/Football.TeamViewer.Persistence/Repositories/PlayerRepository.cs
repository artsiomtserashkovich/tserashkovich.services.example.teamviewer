using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Football.TeamViewer.Application.Players;
using Football.TeamViewer.Domain;
using Microsoft.EntityFrameworkCore;

namespace Football.TeamViewer.Persistence.Repositories
{
    internal class PlayerRepository : IPlayerRepository
    {
        private readonly TeamViewerDatabaseContext _databaseContext;

        public PlayerRepository(TeamViewerDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IReadOnlyCollection<Player>> GetByManagerId(Guid managerId)
        {
            var team = await _databaseContext
                .Teams
                .Include(t => t.Players)
                .FirstOrDefaultAsync(t => t.ManagerId == managerId);

            return team.Players;
        }

        public async Task<bool> Create(Guid managerId, Player player)
        {
            // TODO: try to compose all logics into a single query
            var teamId = await _databaseContext
                .Teams
                .Where(t => t.ManagerId == managerId)
                .Select(t => t.Id)
                .FirstOrDefaultAsync();

            if (teamId == default)
            {
                return false;
            }

            player.Team = new Team
            {
                Id = teamId
            };

            await _databaseContext.AddAsync(player);
            await _databaseContext.SaveChangesAsync();

            return true;
        }
    }
}