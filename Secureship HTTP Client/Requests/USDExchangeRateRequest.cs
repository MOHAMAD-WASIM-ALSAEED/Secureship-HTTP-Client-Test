using System.ComponentModel.DataAnnotations;

namespace Secureship_HTTP_Client.Requests
{
    public record USDExchangeRateRequest
    {
        [Required(ErrorMessage = "Amount is required")]
        public double Amount { get; init; }

        [Required(ErrorMessage = "To currency is required")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "To currency must be exactly 3 characters")]
        public string To { get; init; }
    }
}
