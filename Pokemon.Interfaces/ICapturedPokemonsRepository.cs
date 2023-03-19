using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pokemon.Interfaces
{
    public interface ICapturedPokemonsRepository
    {
        Task AddPokemonToMasterPocket(int masterId, int pokemonId);
        Task<List<Domain.Pokemons.Pokemon>> GetCapturedPokemonsByMasterId(int id);
        Task RemovePokemonOfMasterPocket(int id);
    }
}