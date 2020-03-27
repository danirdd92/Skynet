﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public virtual Country Country { get; set; }
        public virtual List<Flight> Flights { get; set; }
    }
}
