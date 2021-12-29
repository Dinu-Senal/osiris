using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Osiris.Data
{
    public class Company
    {
        [Key]
        public Guid CompanyId { get; set; }

        [Required]
        [StringLength(50)]
        public String Name { get; set; }

        [StringLength(130)]
        public String Description { get; set; }

        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
    }
}
