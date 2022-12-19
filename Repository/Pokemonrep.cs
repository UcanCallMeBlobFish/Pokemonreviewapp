using Pokemonreviewapp.Data;
using Pokemonreviewapp.Interface;
using Pokemonreviewapp.Models;

namespace Pokemonreviewapp.Repository;

public class Pokemonrep : Ipokemonrep
{
    private readonly DataContext _context;
    
    public Pokemonrep(DataContext context)
    {
        _context = context;
    }

    public ICollection<Pokemon> Getpokemons()
    {
        return _context.Pokemon.OrderBy(a => a.Id).ToList();
    }

    public Pokemon GetPokemon(int id)
    {
        return _context.Pokemon.Where(p => p.Id == id).FirstOrDefault();
    }

    public Pokemon GetPokemon(string name)
    {
        return _context.Pokemon.Where(p => p.Name == name).FirstOrDefault();
    }

    public decimal GetPokemonRating(int pokeId)
    {
        var review = _context.Reviews.Where(p => p.Pokemon.Id == pokeId);
        if (review.Count() <= 0)
            return 0;
        return ((decimal)review.Sum(r => r.Rating) / review.Count());
    }

    public bool PokemonExists(int pokeId)
    {
        return _context.Pokemon.Any(p => p.Id == pokeId);
    }
}