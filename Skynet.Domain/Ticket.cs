using System.ComponentModel.DataAnnotations;

namespace Skynet.Domain
{
    public class Ticket
    {
        [Required]
        public int FlightId { get; set; }

        [Required]
        public int CustomerId { get; set; }


        public virtual Flight Flight { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
