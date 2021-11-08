using Football.TeamViewer.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Football.TeamViewer.Persistence.Configurations
{
    internal class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(t => t.Id);
            builder
                .HasOne(t => t.Coach)
                .WithOne(c => c.Team);
            builder.Property(t => t.ManagerId).IsRequired();
            builder
                .HasMany(t => t.Players)
                .WithOne(p => p.Team);
        }
    }
}