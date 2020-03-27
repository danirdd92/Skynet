using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Skynet.Domain
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(128)]
        public string Password { get; set; }


        public virtual UserDescription UserDescription { get; set; }
        public virtual List<Ticket> Tickets { get; set; }
    }
}
