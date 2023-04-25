namespace LibraryRegisterAPI.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents a book entity.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Gets or sets the ID of the book.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the book.
        /// </summary>
        [Required]
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the author of the book.
        /// </summary>
        [Required]
        public string? Author { get; set; }

        /// <summary>
        /// Gets or sets the publisher of the book.
        /// </summary>
        [Required]
        public string? Publisher { get; set; }

        /// <summary>
        /// Gets or sets the publish date of the book.
        /// </summary>
        [Required]
        public DateTime PublishDate { get; set; }
    }
}
