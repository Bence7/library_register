namespace LibraryRegisterAPI.Models
{
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
        public int RentalStatus { get; set; }
    }
}
