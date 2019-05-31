using Microsoft.EntityFrameworkCore;

namespace MovieBomb.Data
{
    public class MovieBombContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=moviebomb;Username=moviebomb;Password=moviebomb-password");

        public DbSet<MovieBomb.Models.Game> Game { get; set; }
        public DbSet<MovieBomb.Models.Round> Round { get; set; }
        public DbSet<MovieBomb.Models.Turn> Turn { get; set; }
        public DbSet<MovieBomb.Models.Player> Player { get; set; }
    }
}
