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
        public String Designation { get; set; }

        public Boolean Type { get; set; }

        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
