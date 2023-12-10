using System.ComponentModel.DataAnnotations;

namespace Secureship_HTTP_Client.Data.Entities
{
    public record EndPointStatistic
    {
        [Key]
        public int Id { get; set; }
        public bool isSuccessfulRequest { get; set; }
        public DateTime RequestDate { get; set; } = DateTime.Now;
    }
}
