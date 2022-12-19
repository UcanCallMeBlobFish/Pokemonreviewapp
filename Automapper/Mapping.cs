using AutoMapper;
using Pokemonreviewapp.DTO;
using Pokemonreviewapp.Models;

namespace Pokemonreviewapp.Automapper;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<Pokemon, PokemonDto>();
        CreateMap<Category, CategoryDto>();
    }
}