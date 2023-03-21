using Pokemon.Models.Pokemons;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Interfaces.Services
{
    public interface IPokemonService
    {
        Task<PokemonModel> GetPokemonById(int id);
        Task<PokemonModel> GetPokemonByName(string name);
        Task SetAsCaptured(int pokemonId, int masterId);
        Task<List<PokemonModel>> GetCapturedPokemons(int masterId);
    }
}
