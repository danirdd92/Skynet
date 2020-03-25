using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Skynet.Domain
{
    public class Ticket
    {
        [Required]
        public int FlightId { get; set; }
        [Required]
        public int UserId { get; set; }


        public Flight Flight { get; set; }
        public User User { get; set; }
    }
}
