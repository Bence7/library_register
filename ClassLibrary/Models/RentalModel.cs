using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Models;

public class RentalModel
{
    [Required]
    public int BookId { get; set; }
    
    [Required]
    public int CustomerId { get; set; }
    
    [Required]
    public DateTime RentalStartDate { get; set; }
    
    [Required]
    public DateTime RentalEndDate { get; set; }
}