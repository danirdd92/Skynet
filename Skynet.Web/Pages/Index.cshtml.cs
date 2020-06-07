using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Skynet.Data.UnitOfWork;
using Skynet.Domain;
using Skynet.Web.Models;

namespace Skynet.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUnitOfWork _db;

        public (IEnumerable<Flight>, List<string>) CollectedFlights { get; set; }

        private List<FlightModel> _flights = new List<FlightModel>();

        public List<FlightModel> Flights
        {
            get { return _flights; }
            set { _flights = value; }
        }


        public IndexModel(ILogger<IndexModel> logger, IUnitOfWork db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task OnGetAsync()
        {
            CollectedFlights = await _db.Flights.GetUpcomingFlightsAsync();
            
            for (int i = 0; i < CollectedFlights.Item1.Count(); i++)
            {
                Flights.Add(new FlightModel
                {
                    Id = CollectedFlights.Item2[i],
                    OutboundCountry = CollectedFlights.Item1.ElementAt(i).OriginCountry.Name,
                    DepartureTime = CollectedFlights.Item1.ElementAt(i).Departure,
                    InboundCountry = CollectedFlights.Item1.ElementAt(i).DestinationCountry.Name,
                    ArrivalTime = CollectedFlights.Item1.ElementAt(i).Arrival
                });
            }
        }
    }
}
