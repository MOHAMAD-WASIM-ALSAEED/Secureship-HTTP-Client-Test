namespace Secureship_HTTP_Client.Models
{
    public record StatisticModel
    {
        public DateTime? LastSuccessRequestDate { get; set; }
        public DateTime? LastFailedRequestDate { get; set; }
        public int FailedRequestsCount { get; set; }
        public int SuccessRequestsCount { get; set; }
    }
}
