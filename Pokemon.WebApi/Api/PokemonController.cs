using Pokemon.Interfaces.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Pokemon.WebApi.Api
{
    [RoutePrefix("api/Pokemon")]
    public class PokemonController : ApiController
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet]
        [Route("GetPokemon")]
        public async Task<IHttpActionResult> GetPokemon(string name)
        {
            return Ok(await _pokemonService.GetPokemonByName(name));
        }
                
        [HttpGet]
        [Route("GetCaptured")]
        public async Task<IHttpActionResult> GetCapturedPokemonsByMaster(int masterId)
        {
            var pokemonList = await _pokemonService.GetCapturedPokemons(masterId);

            return Ok(pokemonList);
        }

        [HttpPost]
        [Route("SetAsCaptured")]
        public async Task<IHttpActionResult> SetPokemonAsCaptured(int pokemonId, int masterId)
        {
            await _pokemonService.SetAsCaptured(pokemonId, masterId);

            return Ok();
        }
    }
}