using System.ComponentModel.DataAnnotations;

namespace LibraryAdminApp.Model;

public class MemberModel
{
    public int Id { get; set; }
    
    [Required]
    public string? Name { get; set; }
    
    [Required]
    public string? Address { get; set; }
    
    [Required]
    public DateTime BirthDate { get; set; }

    public override string ToString()
    {
        return Id + " " + Name + " " + Address + " " + BirthDate;
    }
}