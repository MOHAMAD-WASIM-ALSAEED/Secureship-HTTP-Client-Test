using System.Net;
using AutoFixture;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Secureship_HTTP_Client.Controllers;
using Secureship_HTTP_Client.Interfaces;
using Secureship_HTTP_Client.Models;
using Secureship_HTTP_Client.Requests;
using Secureship_HTTP_Client.Responses;

namespace Secureship_HTTP_Client.Tests.Controllers
{
    public class CurrencyExchangeControllerTests
    {
        private readonly Fixture _fixture;
        public CurrencyExchangeControllerTests()
        {
            _fixture = new Fixture();
        }
        [Fact]
        public async Task ConvertCurrency_ValidRequest_ReturnsOk()
        {
            // Arrange
            var openExchangeRatesServiceMock = new Mock<IOpenExchangeRatesAPIService>();
            var endPointStatisticServiceMock = new Mock<IEndPointStatisticService>();
            var loggerMock = new Mock<ILogger<CurrencyExchangeController>>();
            var mapperMock = new Mock<IMapper>();

            var controller = new CurrencyExchangeController(
                openExchangeRatesServiceMock.Object,
                endPointStatisticServiceMock.Object,
                loggerMock.Object,
                mapperMock.Object
            );

            var request = _fixture.Create<USDExchangeRateRequest>(); // Using AutoFixture to create request object

            var currencyExchangeModel = new CurrencyExchangeModel(Amount: request.Amount, To: request.To, From: "USD");
            var exchangeResponseResult = new ConvertCurrencyResponse(Rate: double.MaxValue, Timestamp: long.MaxValue, ConvertedCurrecncyAmount: double.MaxValue);
            openExchangeRatesServiceMock.Setup(service => service.ConvertCurrencyAsync(currencyExchangeModel))
                .ReturnsAsync(exchangeResponseResult);

            // Act
            var result = await controller.ConvertCurrency(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact]
        public async Task ConvertCurrency_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            var openExchangeRatesServiceMock = new Mock<IOpenExchangeRatesAPIService>();
            var endPointStatisticServiceMock = new Mock<IEndPointStatisticService>();
            var loggerMock = new Mock<ILogger<CurrencyExchangeController>>();
            var mapperMock = new Mock<IMapper>();

            var controller = new CurrencyExchangeController(
                openExchangeRatesServiceMock.Object,
                endPointStatisticServiceMock.Object,
                loggerMock.Object,
                mapperMock.Object
            );

            var invalidRequest = _fixture.Build<USDExchangeRateRequest>().Without(x => x.Amount).Create(); // Using AutoFixture to create an invalid request object

            controller.ModelState.AddModelError("Amount", "Amount is required");

            // Act
            var result = await controller.ConvertCurrency(invalidRequest);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }
    }
}

