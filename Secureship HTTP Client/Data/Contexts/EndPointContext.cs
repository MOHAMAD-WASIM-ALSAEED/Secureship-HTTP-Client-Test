using Microsoft.EntityFrameworkCore;
using Secureship_HTTP_Client.Data.Entities;

namespace Secureship_HTTP_Client.Data.Contexts
{
    public class EndPointContext : DbContext
    {
        public EndPointContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<EndPointStatistic> EndPointStatistics { get; set; }
    }
}
