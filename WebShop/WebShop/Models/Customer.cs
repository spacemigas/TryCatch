using System.ComponentModel.DataAnnotations;

namespace WebShop
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [Required, MaxLength(50)]
        public string Email { get; set; }

        [Required, MaxLength(50)]
        public string Title { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required, MaxLength(50)]
        public string Address { get; set; }

        [Required, MaxLength(50)]
        public string HouseNumber { get; set; }

        [Required, MaxLength(50)]
        public string City { get; set; }

        [Required, MaxLength(50)]
        public string ZipCode { get; set; }
    }
}