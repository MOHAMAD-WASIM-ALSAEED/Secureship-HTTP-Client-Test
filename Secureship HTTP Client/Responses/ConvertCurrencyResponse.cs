namespace Secureship_HTTP_Client.Responses
{
    public record ConvertCurrencyResponse(
        double ConvertedCurrecncyAmount,
        long Timestamp,
        double Rate);
}
