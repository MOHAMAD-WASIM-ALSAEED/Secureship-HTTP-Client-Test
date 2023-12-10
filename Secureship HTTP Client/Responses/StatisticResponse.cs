namespace Secureship_HTTP_Client.Responses
{
    public record StatisticResponse
    {
        public DateTime? LastSuccessRequestDate { get; set; }
        public DateTime? LastFailedRequestDate { get; set; }
        public int FailedRequestsCount { get; set; }
        public int SuccessRequestsCount { get; set; }
    }
}
