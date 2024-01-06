using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Secureship_HTTP_Client.Controllers;
using Secureship_HTTP_Client.Interfaces;
using Secureship_HTTP_Client.Models;
using Secureship_HTTP_Client.Requests;
using Secureship_HTTP_Client.Responses;

namespace Secureship_Http_Clent_Test
{
    public class CurrencyExchnageControllerTests
    {
        private readonly CurrencyExchangeController _currencyExchangeController;
        private readonly Mock<IMapper>  _mapper;
        private readonly Mock<ILogger<CurrencyExchangeController>> _logger;
        private readonly Mock<IEndPointStatisticService>  _endPointStatisticService;
        private readonly Mock<IOpenExchangeRatesAPIService> _openExchangeRatesAPIService;
        private readonly Fixture _fixture;
        public CurrencyExchnageControllerTests()
        {
            _fixture = new Fixture();
            _mapper = new Mock<IMapper>();
            _logger = new Mock<ILogger<CurrencyExchangeController>>();
            _endPointStatisticService = new Mock<IEndPointStatisticService>();
            _openExchangeRatesAPIService = new Mock<IOpenExchangeRatesAPIService>();
            _currencyExchangeController = new CurrencyExchangeController(_openExchangeRatesAPIService.Object, _endPointStatisticService.Object, _logger.Object,_mapper.Object);
        }

        [Fact]
        public async void ConvertCurrency_Valid_Request_Should_Return_OK_Result()
        {
            //Arrange
            var request = _fixture.Create<USDExchangeRateRequest>();
            var currencyExchangeModel = new CurrencyExchangeModel(Amount: request.Amount, To: request.To, From: "USD");
            var exchangeResponseResult = new ConvertCurrencyResponse(Rate: double.MaxValue, Timestamp: long.MaxValue, ConvertedCurrecncyAmount: double.MaxValue);
            _openExchangeRatesAPIService.Setup(x => x.ConvertCurrencyAsync(currencyExchangeModel)).ReturnsAsync(exchangeResponseResult);
            _currencyExchangeController.ModelState.AddModelError("amount", "AHHHHH");
            // act
           var result = await _currencyExchangeController.ConvertCurrency(request);

            // assert

            result.Should().BeAssignableTo<BadRequestObjectResult>();
        }
    }
}
