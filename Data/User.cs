using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Osiris.Data
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        [StringLength(50)]
        public String Name { get; set; }

        [Required]
        [EmailAddress]
        public String Email { get; set; }

        [Required]
        public String Designation { get; set; }

        public Boolean Type { get; set; }

        [Required]
        [MinLength(6,
        ErrorMessage = "{0} must be {1} or higher")]
        public String Password { get; set; }

        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
