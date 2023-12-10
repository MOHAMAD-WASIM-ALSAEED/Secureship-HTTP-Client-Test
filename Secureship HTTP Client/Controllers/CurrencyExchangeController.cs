using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Refit;
using Secureship_HTTP_Client.Data.Entities;
using Secureship_HTTP_Client.Interfaces;
using Secureship_HTTP_Client.Models;
using Secureship_HTTP_Client.Requests;
using Secureship_HTTP_Client.Responses;
using System.Net;

namespace Secureship_HTTP_Client.Controllers
{
    public class CurrencyExchangeController : ControllerBase
    {
        private readonly IOpenExchangeRatesAPIService _openExchangeRatesAPIService;
        private readonly IEndPointStatisticService _endPointStatisticService;
        private readonly ILogger<CurrencyExchangeController> _logger;
        private readonly IMapper _mapper;
        public CurrencyExchangeController(IOpenExchangeRatesAPIService openExchangeRatesAPIService, IEndPointStatisticService endPointStatisticService, ILogger<CurrencyExchangeController> logger, IMapper mapper)
        {
            _openExchangeRatesAPIService = openExchangeRatesAPIService;
            _endPointStatisticService = endPointStatisticService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Converts USD currency based on the provided request.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/ConvertCurrency
        ///     {
        ///         "To": "EUR",
        ///         "amount": 100
        ///     }
        ///
        /// </remarks>
        /// <param name="convertCurrencyRequest">The request containing currency conversion details.</param>
        /// <returns>The converted currency details.</returns>
        /// <response code="200">Returns the converted currency details.</response>
        /// <response code="400">If the request is invalid.</response>
        /// <response code="500">If an unexpected error occurs.</response>
        /// 
        [ProducesResponseType(typeof(ConvertCurrencyResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]

        [HttpPost("convert")]
        public async Task<IActionResult> ConvertCurrency([FromBody] USDExchangeRateRequest convertCurrencyRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                // set From parameter to USD as this Endpoint dedicated to get exchange rates from USD only
                var currencyExchangeModel = new CurrencyExchangeModel(Amount: convertCurrencyRequest.Amount, To: convertCurrencyRequest.To, From: "USD");
                var exchangeResponseResult = await _openExchangeRatesAPIService.ConvertCurrencyAsync(currencyExchangeModel);
                await StoreAndLogRequestStatusAsync(true, string.Empty);

                return Ok(exchangeResponseResult);
            }
            catch (ApiException ex)
            {
                if (ex.StatusCode >= HttpStatusCode.BadRequest && ex.StatusCode < HttpStatusCode.InternalServerError)
                {
                    await StoreAndLogRequestStatusAsync(false, ex.Message);
                    return BadRequest(ex.Message);
                }
                else
                {
                    await StoreAndLogRequestStatusAsync(false, ex.Message);
                    return StatusCode((int)HttpStatusCode.InternalServerError, "Something went wrong please try again later.");
                }
            }
            catch (Exception ex)
            {
                await StoreAndLogRequestStatusAsync(false, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Something went wrong please try again later.");
            }
        }
        /// <summary>
        /// Retrieves statistics summary for endpoints.
        /// </summary>
        /// <returns>Returns endpoint statistics summary.</returns>
        [HttpGet("statistics")]
        [ProducesResponseType(typeof(StatisticResponse), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Statistics()
        {
            var statisticsModel = await _endPointStatisticService.GetEndpointStatisticsSummaryAsync();
            var statisticsResponse = _mapper.Map<StatisticResponse>(statisticsModel);   
            return Ok(statisticsResponse);
        }
        private async Task StoreAndLogRequestStatusAsync(bool SuccessfullRequest, string errorMessage)
        {
            var endPointStatisticObject = new EndPointStatistic
            {
                isSuccessfulRequest = SuccessfullRequest
            };

            await _endPointStatisticService.AddStatisticAsync(endPointStatisticObject);
            if (!SuccessfullRequest)
            {
                _logger.LogWarning($"Request failed with message {errorMessage}");
            }
        }
    }
}
