using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Skynet.Domain
{
    public class Country
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }


        public virtual List<Flight> OutboundFlights { get; set; }
        public virtual List<Flight> InboundFlights { get; set; }
    }
}