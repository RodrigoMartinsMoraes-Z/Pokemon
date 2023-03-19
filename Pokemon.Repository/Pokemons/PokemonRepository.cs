using Pokemon.Domain.Pokemons;
using Pokemon.Interfaces;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Repository.Pokemons
{
    public class PokemonRepository
    {
        private readonly IContext _context;

        public PokemonRepository(IContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add or Update a pokemon on db
        /// </summary>
        /// <param name="pokemon"></param>
        /// <returns></returns>
        public async Task<Domain.Pokemons.Pokemon> AddOrUpdate(Domain.Pokemons.Pokemon pokemon)
        {
            _context.Pokemons.AddOrUpdate(pokemon);
            await _context.SaveChangesAsync();

            return pokemon;
        }

        /// <summary>
        /// Get a Pokemon by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Domain.Pokemons.Pokemon> GetById(int id)
        {
            return await _context.Pokemons.FindAsync(id);
        }

        /// <summary>
        /// Get Pokemon by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Domain.Pokemons.Pokemon> GetByEmail(string name)
        {
            return await _context.Pokemons.FirstOrDefaultAsync(m => m.Name == name);
        }

     
        /// <summary>
        /// Remove Pokemon by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task RemoveById(int id)
        {
            _context.Pokemons.Remove(await GetById(id));
        }

        /// <summary>
        /// Remove Pokemon
        /// </summary>
        /// <param name="Pokemon"></param>
        /// <returns></returns>
        public Task Remove(Domain.Pokemons.Pokemon Pokemon)
        {
            _context.Pokemons.Remove(Pokemon);

            return Task.CompletedTask;
        }
    }
}
