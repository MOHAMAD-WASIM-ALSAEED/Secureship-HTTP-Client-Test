using Secureship_HTTP_Client.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace Secureship_HTTP_Client.SwaggerRequestExamples
{
    public class ConvertCurrencyRequestExample : IExamplesProvider<USDExchangeRateRequest>
    {
        public USDExchangeRateRequest GetExamples()
        {
            return new USDExchangeRateRequest
            {
                Amount = 100.0,
                To = "EUR"
            };
        }
    }
}
