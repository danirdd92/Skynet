using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skynet.Domain
{
    public class Country
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }


        public List<Flight> OutboundFlights { get; set; }
        public List<Flight> InboundFlights { get; set; }
    }
}