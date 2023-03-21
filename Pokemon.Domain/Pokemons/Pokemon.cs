using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Domain.Pokemons
{
    public class Pokemon
    {
        public int Id { get; set; }
        public int PokeApiId { get; set; }
        [JsonProperty("base_experience")]
        public int BaseExperience { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Name { get; set; }
        public string Sprite { get; set; }
    }
}

