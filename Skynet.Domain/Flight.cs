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


        public virtual Airline Airline { get; set; }
        public virtual List<Ticket> Tickets { get; set; }
        public virtual Country OriginCountry { get; set; }
        public virtual Country DestinationCountry { get; set; }


    }
}
