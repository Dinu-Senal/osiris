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
        public String Name { get; set; }

        public Boolean Type { get; set; }

        public Company Company { get; set; }
        public List<Project> Projects { get; set; }
    }
}
