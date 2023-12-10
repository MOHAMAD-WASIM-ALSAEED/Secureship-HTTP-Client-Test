using AutoMapper;
using Secureship_HTTP_Client.Models;
using Secureship_HTTP_Client.Responses;

namespace Secureship_HTTP_Client.MappingProfiles
{
    public class StatisticProfile : Profile
    {
        public StatisticProfile()
        {
            CreateMap<StatisticModel, StatisticResponse>();
        }
    }
}
