using Pokemon.WebApi.Models.Pokemons;

using System.Collections.Generic;

namespace Pokemon.WebApi.Models.Masters
{
    public class MasterModel
    {
        public int Age { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }

        public virtual List<PokemonModel> PokeList { get; set; }
    }
}
