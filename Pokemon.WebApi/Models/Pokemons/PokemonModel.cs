using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.WebApi.Models.Pokemons
{
    public class PokemonModel
    {     
        public int BaseExperience { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Name { get; set; }
        public string Sprite { get; set; }
    }
}

