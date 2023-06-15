using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Models;

public class RentalModel
{
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

    public MemberModel Member { get; set; }

    [Required]
    public int BookId { get; set; }

    public BookModel Book { get; set; }
}