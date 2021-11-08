using Football.TeamViewer.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Football.TeamViewer.Persistence.Configurations
{
    internal class CoachConfiguration : IEntityTypeConfiguration<Coach>
    {
        public void Configure(EntityTypeBuilder<Coach> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .HasOne(f => f.Team)
                .WithOne(p => p.Coach);
        }
    }
}