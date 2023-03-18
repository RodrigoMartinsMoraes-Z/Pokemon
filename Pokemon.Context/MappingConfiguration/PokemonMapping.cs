using Pokemon.Domain.Pokemons;

using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Context.MappingConfiguration
{
    public class PokemonMapping : EntityTypeConfiguration<Domain.Pokemons.Pokemon>
    {
        public PokemonMapping()
        {
            HasKey(p => p.Id);

        }
    }
}
