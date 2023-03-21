using Pokemon.Context.MappingConfiguration;
using Pokemon.Domain.Masters;
using Pokemon.Interfaces;

using System.Data.Entity;
using System.Data.SQLite;

namespace Pokemon.Context
{
    public class PokemonDbContext : DbContext, IContext
    {
        public PokemonDbContext() : base("name=PokemonDb")
        {
        }

        public DbSet<Domain.Pokemons.Pokemon> Pokemons { get; set; }
        public DbSet<Master> Masters { get; set; }
        public DbSet<CapturedPokemons> CapturedPokemons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MasterMapping());
            modelBuilder.Configurations.Add(new CapturedPokemonsMapping());
            modelBuilder.Configurations.Add(new PokemonMapping());

            base.OnModelCreating(modelBuilder);
        }

        public bool Exist()
        {
            return this.Database.Exists();
        }

    }
}
