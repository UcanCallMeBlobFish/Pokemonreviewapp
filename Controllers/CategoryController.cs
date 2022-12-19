using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pokemonreviewapp.DTO;
using Pokemonreviewapp.Interface;

namespace Pokemonreviewapp.Controllers;
[Route("api/[controller]")]
[ApiController]

public class CategoryController : Controller
{
    private readonly ICategoryRep _categoryRep;
    private readonly IMapper _mapper;
    public CategoryController(ICategoryRep categoryRep, IMapper mapper)
    {
        _categoryRep = categoryRep;
        _mapper = mapper;
    }
    [HttpGet]
    
    public IActionResult GetCategories()
    {
        var category = _mapper.Map<List<CategoryDto>>(_categoryRep.GetCategories());

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(category);
    }
    
    [HttpGet("{categoryId}")]
    public IActionResult GetCategory(int categoryId)
    {
        if (!_categoryRep.CategoryExists(categoryId))
            return NotFound();
        var category = _mapper.Map<CategoryDto>(_categoryRep.GetCategory(categoryId) );
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(category);
            
    }

    [HttpGet("pokemon/{categoryId}")]
    public IActionResult GetPokemonByCategoryId(int categoryId)
    {
        var pokemons = _mapper.Map<List<PokemonDto>>(_categoryRep.GetPokemonByCategory(categoryId));
        return Ok(pokemons);

    }
}