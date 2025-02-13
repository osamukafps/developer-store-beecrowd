using AutoMapper;
using DeveloperStore.Api.Application.DTOs;
using DeveloperStore.Api.Domain.Entities;

namespace DeveloperStore.Api.Application.Mappings;

public class DomainToDtoMappingProfile : Profile
{
    public DomainToDtoMappingProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForPath(d => d.AverageRating,
                o => o.MapFrom(s => s.Rating.Rate))
            .ForPath(d => d.RatingCount,
                o => o.MapFrom(s => s.Rating.Count));
    }
    
}