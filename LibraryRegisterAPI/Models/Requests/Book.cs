namespace LibraryRegisterAPI.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Author { get; set; }

        [Required]
        public string? Publisher { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }
    }
}
