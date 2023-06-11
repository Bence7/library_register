namespace LibraryRegisterAPI.Models.Entities
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Rental
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime RentalStartDate { get; set; }

        [Required]
        public DateTime RentalEndDate { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool RentalStatus { get; set; }

        [Required]
        public int MemberId { get; set; }

        public Member Member { get; set; }

        [Required]
        public int BookId { get; set; }

        public Book Book { get; set; }
    }
}
