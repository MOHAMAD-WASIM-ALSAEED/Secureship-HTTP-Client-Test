using Refit;
using Secureship_HTTP_Client.Responses;

namespace Secureship_HTTP_Client.Interfaces
{
    /// <summary>
    /// Interface defining methods to interact with the Open Exchange Rates API.
    /// </summary>
    public interface IOpenExchangeRatesAPI
    {
        /// <summary>
        /// Gets the exchange rate between two currencies for a specified amount.
        /// </summary>
        /// <param name="amount">The amount of currency to convert.</param>
        /// <param name="from">The currency code to convert from.</param>
        /// <param name="to">The currency code to convert to.</param>
        /// <param name="app_id">The API key for accessing the Open Exchange Rates API.</param>
        /// <returns>The exchange rate response containing conversion details.</returns>
        [Get("/convert/{amount}/{from}/{to}")]
        Task<ExchangeRateResponse> GetExchangeRateAsync(double amount, string from, string to, [Query][AliasAs("app_id")] string appId);
    }
}
