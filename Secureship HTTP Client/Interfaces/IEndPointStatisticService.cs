using Secureship_HTTP_Client.Data.Entities;
using Secureship_HTTP_Client.Models;

namespace Secureship_HTTP_Client.Interfaces
{
    public interface IEndPointStatisticService
    {
        Task<EndPointStatistic> GetStatisticByIdAsync(int id);
        Task<List<EndPointStatistic>> GetAllStatisticsAsync();
        Task AddStatisticAsync(EndPointStatistic statistic);
        Task UpdateStatisticAsync(EndPointStatistic statistic);
        Task DeleteStatisticAsync(int id);
        Task<StatisticModel> GetEndpointStatisticsSummaryAsync();
    }
}
