using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InlandMarinaData
{
    [Table("Customer")]
    public class Customer
    {
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required]
        [StringLength(15)]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Phone must be in the format XXX-XXX-XXXX")]

        public string Phone { get; set; }

        [Required]
        [StringLength(30)]
        public string City { get; set; }

        public string? AspNetUserId { get; set; }

        // navigation property
        public virtual ICollection<Lease> Leases { get; set; }
    }

}
