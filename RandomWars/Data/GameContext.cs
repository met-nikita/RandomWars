
using Microsoft.EntityFrameworkCore;

namespace RandomWars.Data
{
    public class GameContext: DbContext
    {
        public DbSet<CharacterStandard> Characters { get; set; }
        public DbSet<CharacteristicChange> CharacteristicChanges { get; set; }
        public DbSet<EventAttack> EventAttacks { get; set; }
        public DbSet<EventCommon> EventCommons { get; set; }
        public DbSet<EventReact> EventReactes { get; set; }

        public DbSet<StatusChange> StatusChanges { get; set; }

        public string DbPath { get; }
        public GameContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "RandomWarsGame.db");
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer($"Data Source={DbPath}");
    }
}
