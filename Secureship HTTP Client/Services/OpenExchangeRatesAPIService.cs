using AutoMapper;
using Secureship_HTTP_Client.Interfaces;
using Secureship_HTTP_Client.Models;
using Secureship_HTTP_Client.Responses;

namespace Secureship_HTTP_Client.Services
{
    public class OpenExchangeRatesAPIService : IOpenExchangeRatesAPIService
    {
        private readonly IOpenExchangeRatesAPI _openExchangeRatesAPI;
        private readonly string _openExchangeAPIAppId;
        private readonly IMapper _mapper;

        public OpenExchangeRatesAPIService(IOpenExchangeRatesAPI openExchangeRatesAPI, IConfiguration configuration, IMapper mapper)
        {
            _openExchangeRatesAPI = openExchangeRatesAPI;
            _openExchangeAPIAppId = configuration["OpenExchangeAPI:AppId"];
            _mapper = mapper;
        }

        public async Task<ConvertCurrencyResponse> ConvertCurrencyAsync(CurrencyExchangeModel  currencyExchangeModel)
        {
            var exchangeRateResponseOject = await _openExchangeRatesAPI.GetExchangeRateAsync(amount: currencyExchangeModel.Amount, from: currencyExchangeModel.From, to: currencyExchangeModel.To, appId: _openExchangeAPIAppId);
            var excahngeResponseModel = _mapper.Map<ConvertCurrencyResponse>(exchangeRateResponseOject);
            return excahngeResponseModel;
        }
    }
}
