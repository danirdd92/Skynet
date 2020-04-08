using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skynet.Domain
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(128)]
        public string LastName { get; set; }

        public int Age { get; set; }


        public virtual CustomerIdentity CustomerIdentity { get; set; }
        public virtual List<Ticket> Tickets { get; set; }
    }
}
