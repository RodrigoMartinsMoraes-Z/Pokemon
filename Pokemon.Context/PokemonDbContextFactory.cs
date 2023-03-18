using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Context
{
    public class PokemonDbContextFactory : IDbContextFactory<PokemonDbContext>
    {
        public PokemonDbContext Create()
        {
            return new PokemonDbContext();
        }
    }
}
