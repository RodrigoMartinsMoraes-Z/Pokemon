using AutoMapper;

using Pokemon.Models.Pokemons;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.AutoMapper
{
    public class PokemonMappingProfile : Profile
    {
        public PokemonMappingProfile()
        {
            CreateMap<Domain.Pokemons.Pokemon, PokemonModel>();
            CreateMap<PokemonModel, Domain.Pokemons.Pokemon>();
        }
    }
}
