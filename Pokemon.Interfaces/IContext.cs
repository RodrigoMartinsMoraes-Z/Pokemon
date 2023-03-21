using Pokemon.Domain.Masters;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Interfaces
{
    public interface IContext
    {
        DbSet<Domain.Pokemons.Pokemon> Pokemons { get; }
        DbSet<Master> Masters { get; }
        DbSet<CapturedPokemons> CapturedPokemons { get; }

        bool Exist();
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
