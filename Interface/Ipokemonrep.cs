using Pokemonreviewapp.Models;

namespace Pokemonreviewapp.Interface;

public interface Ipokemonrep
{
    ICollection<Pokemon> Getpokemons();
    Pokemon GetPokemon(int id);
    Pokemon GetPokemon(string name);
    decimal GetPokemonRating(int pokeId);
    bool PokemonExists(int pokeId);
}