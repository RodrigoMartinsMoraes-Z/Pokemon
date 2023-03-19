using System.Threading.Tasks;

namespace Pokemon.Interfaces
{
    public interface IPokemonRepository
    {
        Task<Domain.Pokemons.Pokemon> AddOrUpdate(Domain.Pokemons.Pokemon pokemon);
        Task<Domain.Pokemons.Pokemon> GetByEmail(string name);
        Task<Domain.Pokemons.Pokemon> GetById(int id);
        Task Remove(Domain.Pokemons.Pokemon Pokemon);
        Task RemoveById(int id);
    }
}