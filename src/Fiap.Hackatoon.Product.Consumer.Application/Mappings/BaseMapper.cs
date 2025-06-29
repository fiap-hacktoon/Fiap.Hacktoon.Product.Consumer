using AutoMapper;
using DTO = Fiap.Hackatoon.Product.Consumer.Application.DataTransferObjects;
using Fiap.Hackatoon.Product.Consumer.Domain.Entities;

namespace Fiap.Hackatoon.Product.Consumer.Application.Mappings;

public class BaseMapper : Profile
{
    public BaseMapper()
    {
        CreateMap<DTO.BaseModel, BaseEntity>()
            .ForMember(dest => dest.Id, opt =>
            {
                opt.Condition(src => src.Id.HasValue == false || src.Id.Value == default);
                opt.UseDestinationValue();
            })
            .ForMember(dest => dest.Id, opt =>
            {
                opt.Condition(src => src.Id.HasValue == true && src.Id.Value != default);
                opt.MapFrom(src => src.Id);
            });
    }
}
