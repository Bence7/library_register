using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary.Models;

public class MemberModel
{
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Address { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }
}