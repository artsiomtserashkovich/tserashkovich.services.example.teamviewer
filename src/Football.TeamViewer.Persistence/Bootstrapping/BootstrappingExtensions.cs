using Football.TeamViewer.Application.Games;
using Football.TeamViewer.Application.Players;
using Football.TeamViewer.Application.Teams;
using Football.TeamViewer.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Football.TeamViewer.Persistence.Bootstrapping
{
    public static class BootstrappingExtensions
    {
        public static IServiceCollection AddDatabaseSupport(this IServiceCollection services)
        {
            services.AddDbContext<TeamViewerDatabaseContext>(
                    options => options.UseInMemoryDatabase("Main"));

            services.AddRepositories();

            return services;
        }

        internal static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services
                .AddScoped<IPlayerRepository, PlayerRepository>()
                .AddScoped<ITeamRepository, TeamRepository>()
                .AddScoped<IGameRepository, GameRepository>();

            return services;
        }
    }
}