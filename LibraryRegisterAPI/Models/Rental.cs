namespace LibraryRegisterAPI.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents a rental entity.
    /// </summary>
    public class Rental
    {
        /// <summary>
        /// Gets or sets the ID of the book being rented.
        /// </summary>
        [Required]
        public int BookId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the customer who is renting the book.
        /// </summary>
        [Required]
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the start date of the rental period.
        /// </summary>
        [Required]
        public DateTime RentalStartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date of the rental period.
        /// </summary>
        [Required]
        public DateTime RentalEndDate { get; set; }
    }
}
