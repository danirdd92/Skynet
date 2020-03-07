using System;
using System.Collections.Generic;

namespace Skynet.Domain.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public int AirlineId { get; set; }
        public int OriginCountryId { get; set; }
        public int DestinationCountryId { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Landing { get; set; }
        public ICollection<Ticket> RamainingTickets { get; set; }
    }
}
