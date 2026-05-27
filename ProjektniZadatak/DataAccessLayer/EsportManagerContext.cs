using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjektniZadatak.Model;

namespace ProjektniZadatak.DataAccessLayer
{
    public class EsportManagerContext : IdentityDbContext<User>
    {
        public EsportManagerContext(DbContextOptions<EsportManagerContext> options) : base(options) { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<TournamentRegistration> TournamentRegistrations { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchResult> MatchResults { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Match>()
                .HasOne(m => m.FirstTeam)
                .WithMany()
                .HasForeignKey(m => m.FirstTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Match>()
                .HasOne(m => m.SecondTeam)
                .WithMany()
                .HasForeignKey(m => m.SecondTeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
