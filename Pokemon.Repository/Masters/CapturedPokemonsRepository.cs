using Pokemon.Interfaces;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Repository.Masters
{
    public class CapturedPokemonsRepository : ICapturedPokemonsRepository
    {
        private readonly IContext _context;

        public CapturedPokemonsRepository(IContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get a list of pokemons captured by a master
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<Domain.Pokemons.Pokemon>> GetCapturedPokemonsByMasterId(int id)
        {
            List<int> capturedPokemons = await _context.CapturedPokemons.Where(cp => cp.MasterId == id).Select(cp => cp.PokemonId).ToListAsync();

            List<Domain.Pokemons.Pokemon> pokemons = await _context.Pokemons.Where(p => capturedPokemons.Contains(p.Id)).ToListAsync();

            return pokemons;
        }

        /// <summary>
        /// Add pokemon to master pocket
        /// </summary>
        /// <param name="masterId"></param>
        /// <param name="pokemonId"></param>
        /// <returns></returns>
        public Task AddPokemonToMasterPocket(int masterId, int pokemonId)
        {
            _context.CapturedPokemons.Add(new Domain.Masters.CapturedPokemons { MasterId = masterId, PokemonId = pokemonId });

            return Task.CompletedTask;
        }

        /// <summary>
        /// Remove a Pokemon from Master Pocket
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task RemovePokemonOfMasterPocket(int id)
        {
            _context.CapturedPokemons.Remove(_context.CapturedPokemons.Find(id));

            return Task.CompletedTask;
        }
    }
}
