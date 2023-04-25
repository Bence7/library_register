namespace LibraryRegisterAPI.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents a customer entity.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Gets or sets the ID of the customer.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        [Required]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the address of the customer.
        /// </summary>
        [Required]
        public string? Address { get; set; }

        /// <summary>
        /// Gets or sets the birth date of the customer.
        /// </summary>
        [Required]
        public DateTime BirthDate { get; set; }
    }
}
