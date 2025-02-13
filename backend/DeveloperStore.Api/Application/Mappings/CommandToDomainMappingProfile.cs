using AutoMapper;
using DeveloperStore.Api.Application.Mediator.Commands;
using DeveloperStore.Api.Domain.Entities;

namespace DeveloperStore.Api.Application.Mappings;

public class CommandToDomainMappingProfile : Profile
{
    public CommandToDomainMappingProfile()
    {
        CreateMap<CreateProductCommand, Product>().ReverseMap();
    }
}