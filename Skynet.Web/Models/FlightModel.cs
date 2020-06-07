using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skynet.Web.Models
{
    public class FlightModel
    {
        public string Id { get; set; }
        public string OutboundCountry { get; set; }
        public DateTime DepartureTime { get; set; }
        public string InboundCountry { get; set; }
        public DateTime ArrivalTime { get; set; }

        //public FlightModel(string id, string outboundCountry, DateTime departureTime,
        //    string inboundCountry, DateTime arrivalTime)
        //{
        //    Id = id;
        //    OutboundCountry = outboundCountry;
        //    DepartureTime = departureTime;
        //    InboundCountry = inboundCountry;
        //    ArrivalTime = arrivalTime;
        //}
    }
}


// Flight Id
// Departing From
//  Departure 

//  Arriving To
//  Est Arrival