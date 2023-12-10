using Microsoft.EntityFrameworkCore;
using Secureship_HTTP_Client.Data.Contexts;
using Secureship_HTTP_Client.Data.Entities;

namespace Secureship_HTTP_Client.Data.Repositories
{
    public class EndPointStatisticRepository : IEndPointStatisticRepository
    {
        private readonly EndPointContext _endPointContext;

        public EndPointStatisticRepository(EndPointContext endPointContext)
        {
            _endPointContext = endPointContext;
        }

        public async Task<EndPointStatistic> GetByIdAsync(int id)
        {
            return await _endPointContext.EndPointStatistics.FindAsync(id);
        }

        public async Task<List<EndPointStatistic>> GetAllAsync()
        {
            return await _endPointContext.EndPointStatistics.ToListAsync();
        }

        public async Task AddAsync(EndPointStatistic statistic)
        {
            _endPointContext.EndPointStatistics.Add(statistic);
            await _endPointContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(EndPointStatistic statistic)
        {
            _endPointContext.Entry(statistic).State = EntityState.Modified;
            await _endPointContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var statistic = await _endPointContext.EndPointStatistics.FindAsync(id);
            if (statistic != null)
            {
                _endPointContext.EndPointStatistics.Remove(statistic);
                await _endPointContext.SaveChangesAsync();
            }
        }
        public async Task<int> CountSuccessfulRequestsAsync()
        {
            return await _endPointContext.EndPointStatistics.CountAsync(s => s.isSuccessfulRequest);
        }

        public async Task<int> CountFailedRequestsAsync()
        {
            return await _endPointContext.EndPointStatistics.CountAsync(s => !s.isSuccessfulRequest);
        }

        public async Task<DateTime?> GetLastSuccessfulRequestDateAsync()
        {
            return await _endPointContext.EndPointStatistics
                .Where(s => s.isSuccessfulRequest)
                .OrderByDescending(s => s.RequestDate)
                .Select(s => s.RequestDate)
                .FirstOrDefaultAsync();
        }

        public async Task<DateTime?> GetLastFailedRequestDateAsync()
        {
            return await _endPointContext.EndPointStatistics
                .Where(s => !s.isSuccessfulRequest)
                .OrderByDescending(s => s.RequestDate)
                .Select(s => s.RequestDate)
                .FirstOrDefaultAsync();
        }
    }
}
