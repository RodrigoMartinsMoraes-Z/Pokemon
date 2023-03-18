using Pokemon.Domain.Masters;

using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Context.MappingConfiguration
{
    public class CapturedPokemonsMapping : EntityTypeConfiguration<CapturedPokemons>
    {
        public CapturedPokemonsMapping()
        {
            HasKey(cp => cp.Id);

            HasRequired(cp => cp.Master).WithMany(m => m.PokeList).HasForeignKey(cp => cp.MasterId);
            HasRequired(cp => cp.Pokemon).WithMany().HasForeignKey(cp => cp.PokemonId);
        }
    }
}
