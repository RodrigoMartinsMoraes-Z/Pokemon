namespace Pokemon.Domain.Masters
{
    public class CapturedPokemons
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public int PokemonId { get; set; }

        public virtual Master Master { get; set; }
        public virtual Pokemons.Pokemon Pokemon { get; set; }
    }
}
