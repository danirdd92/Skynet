using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Skynet.Domain
{
    public class Flight
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int AirlineId { get; set; }
        [Required]
        public int OriginCountryId { get; set; }
        [Required]
        public int DestinationCountryId { get; set; }
        [Required]
        public DateTime Departure { get; set; }
        [Required]
        public DateTime Arrival { get; set; }
        [Required]
        public int RemainingTickets { get; set; }


        public Airline Airline { get; set; }
        public List<Ticket> Tickets { get; set; }
        public Country OriginCountry { get; set; }
        public Country DestinationCountry { get; set; }


    }
}
