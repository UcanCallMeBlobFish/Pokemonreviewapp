using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pokemonreviewapp.DTO;
// using Pokemonreviewapp.D;
using Pokemonreviewapp.Interface;
using Pokemonreviewapp.Models;

namespace Pokemonreviewapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class PokemonController : Controller
    {
        private readonly Ipokemonrep _pokemonRepository;
        private readonly IMapper _mapper;

        public PokemonController(Ipokemonrep pokemonRepository, IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPokemons()
        {
            var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonRepository.Getpokemons());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemons);
        }

        [HttpGet("{pokeId}")]
        public IActionResult GetPokemon(int pokeId)
        {
            if (!_pokemonRepository.PokemonExists(pokeId))
                return NotFound();
            var pokemon = _mapper.Map<PokemonDto>(_pokemonRepository.GetPokemon(pokeId) );
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(pokemon);
            
            }

        [HttpGet("{pokeId}/rating")]
        public IActionResult GetPokemonRating(int pokeId)
        {
            if( !_pokemonRepository.PokemonExists(pokeId)  )
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var rating = _pokemonRepository.GetPokemonRating((pokeId));
            return Ok(rating);
        }
    }
}