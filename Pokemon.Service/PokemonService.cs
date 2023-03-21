using AutoMapper;

using Newtonsoft.Json;

using Pokemon.Interfaces;
using Pokemon.Interfaces.Services;
using Pokemon.Models.Pokemons;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Service
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;

        public PokemonService(IPokemonRepository pokemonRepository, IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }

        public async Task<PokemonModel> GetPokemonById(int id)
        {
            var pokemon = await _pokemonRepository.GetById(id);

            return _mapper.Map<PokemonModel>(pokemon);
        }

        public async Task<PokemonModel> GetPokemonByName(string name)
        {
            var pokemon = await _pokemonRepository.GetByName(name);

            if (pokemon == null || pokemon.Id < 1)
                pokemon = await GetFromPokeApi(name);

            return _mapper.Map<PokemonModel>(pokemon);
        }

        private async Task<Domain.Pokemons.Pokemon> GetFromPokeApi(string name)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = await client.GetAsync("https://pokeapi.co/api/v2/pokemon/" + name);

                if (result.IsSuccessStatusCode)
                {
                    var pokemonJson = await result.Content.ReadAsStringAsync();

                    var pokemon = JsonConvert.DeserializeObject<Domain.Pokemons.Pokemon>(pokemonJson);

                    pokemon.Sprite = await GetSprite(pokemonJson);

                    pokemon.PokeApiId = pokemon.Id;
                    pokemon.Id = 0;
                    await _pokemonRepository.AddOrUpdate(pokemon);

                    return pokemon;
                }
                else
                {
                    return null;
                }
            }

        }

        private Task<string> GetSprite(string pokemonJson)
        {
            using (var webClient = new WebClient())
            {
                dynamic jsonObj = JsonConvert.DeserializeObject(pokemonJson);

                string frontDefault = jsonObj.sprites.front_default;

                byte[] imageBytes = webClient.DownloadData(frontDefault);

                string base64String = Convert.ToBase64String(imageBytes);

                return Task.FromResult(base64String);
            }
        }
    }
}
