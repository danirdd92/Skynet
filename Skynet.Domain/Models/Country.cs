using Dapper.Contrib.Extensions;

namespace Skynet.Domain.Models
{
    [Table("Countries")]
    public class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
    }
}
