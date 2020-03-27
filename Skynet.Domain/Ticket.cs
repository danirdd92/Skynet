﻿using System;
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


        public virtual Flight Flight { get; set; }
        public virtual User User { get; set; }
    }
}
