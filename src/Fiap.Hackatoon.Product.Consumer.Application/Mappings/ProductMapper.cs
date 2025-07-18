using AutoMapper;
using MSG = Fiap.Hackatoon.Product.Consumer.Application.DataTransferObjects.MessageBrokers;
using DO = Fiap.Hackatoon.Product.Consumer.Domain.Entities;
using DTO = Fiap.Hackatoon.Product.Consumer.Application.DataTransferObjects;
using VIEW = Fiap.Hackatoon.Product.Consumer.Domain.Views.ElasticSearch;
using DTOE = Fiap.Hackatoon.Product.Consumer.Application.DataTransferObjects.ElasticSearch;

namespace Fiap.Hackatoon.Product.Consumer.Application.Mappings;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<DO.Product, MSG.Product>()
            .ReverseMap()
            .ConstructUsing(src => new DO.Product())
            .ForMember(dest => dest.Type, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.RemovedAt, opt => opt.Ignore());

        CreateMap<DO.Product, DTO.Product>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.TypeId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.StockQuantity, opt => opt.MapFrom(src => src.StockQuantity))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.Removed, opt => opt.MapFrom(src => src.Removed))
            .ForMember(dest => dest.RemovedAt, opt => opt.MapFrom(src => src.RemovedAt))
            .ReverseMap()
            .ConstructUsing(src => new DO.Product())
            .ForMember(dest => dest.Type, opt => opt.Ignore());

        CreateMap<DO.Product, VIEW.ProductByType>()
            .ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.Type.Id))
            .ForMember(dest => dest.TypeCode, opt => opt.MapFrom(src => src.Type.Code))
            .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.Type.Name))
            .ForMember(dest => dest.TypeDescription, opt => opt.MapFrom(src => src.Type.Description))
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Name));

        CreateMap<VIEW.ProductByType, DTOE.ProductByType>()
            .ReverseMap();
            
        CreateMap<DTOE.ProductByType, DTO.Product>()
            .ForMember(dest => dest.Id, opt =>
            {
                opt.Condition(src => src.Id.HasValue == false || src.Id.Value == default);
                opt.UseDestinationValue();
            })
            .ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.TypeId))
            .ReverseMap();
    }
}