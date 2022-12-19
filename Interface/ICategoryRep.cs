using Pokemonreviewapp.Models;

namespace Pokemonreviewapp.Interface;

public interface ICategoryRep
{
    ICollection<Category> GetCategories();
    Category GetCategory(int id);
    ICollection<Pokemon> GetPokemonByCategory(int categoryId);
    bool CategoryExists(int id);
    

}