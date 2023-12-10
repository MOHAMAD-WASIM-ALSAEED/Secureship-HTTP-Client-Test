using Secureship_HTTP_Client.Data.Entities;

namespace Secureship_HTTP_Client.Data.Repositories
{
    public interface IEndPointStatisticRepository : IRepository<EndPointStatistic>
    {
        Task<int> CountFailedRequestsAsync();
        Task<int> CountSuccessfulRequestsAsync();
        Task<DateTime?> GetLastFailedRequestDateAsync();
        Task<DateTime?> GetLastSuccessfulRequestDateAsync();
    }
}
