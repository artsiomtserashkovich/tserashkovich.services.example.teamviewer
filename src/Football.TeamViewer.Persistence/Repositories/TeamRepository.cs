using System;
using System.Linq;
using System.Threading.Tasks;
using Football.TeamViewer.Application.Teams;
using Football.TeamViewer.Domain;
using Microsoft.EntityFrameworkCore;

namespace Football.TeamViewer.Persistence.Repositories
{
    internal class TeamRepository : ITeamRepository
    {
        private readonly TeamViewerDatabaseContext _databaseContext;

        public TeamRepository(TeamViewerDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Task<Team> GetByManagerId(Guid managerId)
        {
            return _databaseContext.Teams
                .Where(t => t.ManagerId == managerId)
                .Include(t => t.Players.Select(p => p.Id))
                .Include(t => t.Coach)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> CreateIfManagerNotHas(Team team)
        {
            // TODO:
            // This implementation not handle race condition when user concurrently create team
            // Must be adjusted
            // Possible solutions:
            // 1) single query
            // 2) transaction
            var currentTeam = await _databaseContext.Teams.FirstOrDefaultAsync(t => t.ManagerId == team.ManagerId);

            if (currentTeam != null)
            {
                return false;
            }

            await _databaseContext.Teams.AddAsync(team);
            await _databaseContext.SaveChangesAsync();

            return true;
        }
    }
}