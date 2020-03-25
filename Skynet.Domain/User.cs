using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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


        public UserDescription UserDescription { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
