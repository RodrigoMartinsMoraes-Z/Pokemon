using Pokemon.Domain.Masters;

using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Context.MappingConfiguration
{
    public class MasterMapping : EntityTypeConfiguration<Master>
    {
        public MasterMapping()
        {
            ToTable("Masters");
            HasKey(m => m.Id);

            HasMany(m => m.PokeList);
        }
    }
}
