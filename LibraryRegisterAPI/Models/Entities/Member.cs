﻿namespace LibraryRegisterAPI.Models.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
    }
}
