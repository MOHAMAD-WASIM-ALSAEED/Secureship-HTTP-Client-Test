using Secureship_HTTP_Client.Models;
using Secureship_HTTP_Client.Responses;

namespace Secureship_HTTP_Client.Interfaces
{
    public interface IOpenExchangeRatesAPIService
    {
        Task<ConvertCurrencyResponse> ConvertCurrencyAsync(CurrencyExchangeModel currencyExchangeModel);
    }
}