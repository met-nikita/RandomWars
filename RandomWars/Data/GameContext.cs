
using Microsoft.EntityFrameworkCore;

namespace RandomWars.Data
{
    public class GameContext: DbContext
    {
        public DbSet<CharacterStandard> CharactersStandrts { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<ChangeCharacteristic> CharacteristicChanges { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventAttack> EventAttacks { get; set; }
        public DbSet<EventCommon> EventCommons { get; set; }
        public DbSet<EventReact> EventReactes { get; set; }
        public DbSet<BaseChange> BaseChanges { get; set; }
        public DbSet<ChangeStatus> StatusChanges { get; set; }

        public string DbPath { get; }
        public GameContext()
        {
            //var folder = Environment.SpecialFolder.LocalApplicationData;
            //var path = Environment.GetFolderPath(folder);
            //DbPath = System.IO.Path.Join(path, "RandomWarsGame.db");
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RandomWarsGame;Trusted_Connection=True;");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // использование Fluent API
            base.OnModelCreating(modelBuilder);
        }

    }
}
