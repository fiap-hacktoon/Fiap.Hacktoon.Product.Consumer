using AutoMapper;
using MSG = Fiap.Hackatoon.Product.Consumer.Application.DataTransferObjects.MessageBrokers;
using DO = Fiap.Hackatoon.Product.Consumer.Domain.Entities;

namespace Fiap.Hackatoon.Product.Consumer.Application.Mappings;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<DO.Product, MSG.Product>()
            .ReverseMap()
            .ConstructUsing(src => new DO.Product())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.RemovedAt, opt => opt.Ignore())
            .ForMember(dest => dest.Removed, opt => opt.Ignore());
    }
}