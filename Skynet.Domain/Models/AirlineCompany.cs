using Dapper.Contrib.Extensions;

namespace Skynet.Domain.Models
{
    [Table("AirlineCompanies")]
    public class AirlineCompany 
    {
        public int Id { get; set; }
        public string AirlineName { get; set; }
        public int CountryId { get; set; }
    }
}
