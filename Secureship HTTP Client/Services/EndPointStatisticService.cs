using Secureship_HTTP_Client.Data.Entities;
using Secureship_HTTP_Client.Data.Repositories;
using Secureship_HTTP_Client.Interfaces;
using Secureship_HTTP_Client.Models;

namespace Secureship_HTTP_Client.Services
{
    public class EndPointStatisticService : IEndPointStatisticService
    {
        private readonly IEndPointStatisticRepository _repository;

        public EndPointStatisticService(IEndPointStatisticRepository repository)
        {
            _repository = repository;
        }

        public async Task<EndPointStatistic> GetStatisticByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<EndPointStatistic>> GetAllStatisticsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddStatisticAsync(EndPointStatistic statistic)
        {
            await _repository.AddAsync(statistic);
        }

        public async Task UpdateStatisticAsync(EndPointStatistic statistic)
        {
            await _repository.UpdateAsync(statistic);
        }

        public async Task DeleteStatisticAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
        public async Task<StatisticModel> GetEndpointStatisticsSummaryAsync()
        {
            var statisticsObject = new StatisticModel()
            {
                FailedRequestsCount = await _repository.CountFailedRequestsAsync(),
                SuccessRequestsCount = await _repository.CountSuccessfulRequestsAsync(),
                LastFailedRequestDate = await _repository.GetLastFailedRequestDateAsync(),
                LastSuccessRequestDate = await _repository.GetLastSuccessfulRequestDateAsync()
            };
            return statisticsObject;
        }
    }

}
