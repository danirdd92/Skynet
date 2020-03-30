using System.ComponentModel.DataAnnotations;

namespace Skynet.Domain
{
    public class UserDescription
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(128)]
        public string LastName { get; set; }

        [MaxLength(128)]
        public string Address { get; set; }

        [MaxLength(128)]
        public string Phone { get; set; }

        [MaxLength(128)]
        public string CreditCard { get; set; }

        [Required]
        public int UserId { get; set; }


        public virtual User User { get; set; }
    }
}