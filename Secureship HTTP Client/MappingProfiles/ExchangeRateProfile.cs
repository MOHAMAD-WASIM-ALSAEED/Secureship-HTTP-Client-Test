using AutoMapper;
using Secureship_HTTP_Client.Responses;

namespace Secureship_HTTP_Client.MappingProfiles
{
    public class ExchangeRateProfile : Profile
    {
        public ExchangeRateProfile()
        {
            CreateMap<ExchangeRateResponse, ConvertCurrencyResponse>()
            .ForMember(dest => dest.ConvertedCurrecncyAmount, opt => opt.MapFrom(src => src.Response))
            .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => src.Meta.Timestamp))
            .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Meta.Rate));
        }
    }
}
