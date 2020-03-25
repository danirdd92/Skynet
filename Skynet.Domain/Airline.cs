using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Skynet.Domain
{
    public class Airline
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        [Required]
        public int CountryId { get; set; }


        public Country Country { get; set; }
        public List<Flight> Flights { get; set; }
    }
}
