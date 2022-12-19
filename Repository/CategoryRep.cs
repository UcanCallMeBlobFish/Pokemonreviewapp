using Pokemonreviewapp.Data;
using Pokemonreviewapp.Interface;
using Pokemonreviewapp.Models;

namespace Pokemonreviewapp.Repository;

public class CategoryRep : ICategoryRep

{
    private DataContext _context;
    public CategoryRep(DataContext context)
    {
        _context = context;
    }
    
    public ICollection<Category> GetCategories()
    {
        return _context.Categories.ToList();
    }

    public Category GetCategory(int id)
    {
        return _context.Categories.Where(e => e.Id == id).FirstOrDefault();
    }

    public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
    {
        return _context.PokemonCategories.Where(c => c.CategoryId == categoryId).Select(t => t.Pokemon).ToList();
    }

    public bool CategoryExists(int id)
    {
        return _context.Categories.Any(c => c.Id == id);
    }
}