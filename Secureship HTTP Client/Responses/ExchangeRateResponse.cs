namespace Secureship_HTTP_Client.Responses
{
    public record ExchangeRateResponse(
        string Disclaimer,
        string License,
        RequestInfo Request,
        MetaInfo Meta,
        double Response
    );

    public record RequestInfo(
        string Query,
        double Amount,
        string From,
        string To
    );

    public record MetaInfo(
        long Timestamp,
        double Rate
    );
}
