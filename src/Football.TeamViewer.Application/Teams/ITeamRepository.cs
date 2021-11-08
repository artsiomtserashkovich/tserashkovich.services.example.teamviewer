using System;
using System.Threading.Tasks;
using Football.TeamViewer.Domain;

namespace Football.TeamViewer.Application.Teams
{
    public interface ITeamRepository
    {
        Task<Team> GetByManagerId(Guid managerId);

        Task<bool> CreateIfManagerNotHas(Team team);
    }
}