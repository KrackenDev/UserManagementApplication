using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.Infrastructure.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        public string Email { get; set; }
        // TODO: This should probably not be able to be set and should be modified only by the database.
        public DateTime? LastModified { get; set; }
        
        public bool IsValid() => !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName);
        
    }
}