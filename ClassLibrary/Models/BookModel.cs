using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Models;

public class BookModel
{
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