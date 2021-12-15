using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Osiris.Data
{
    public class Project
    {
        [Key]
        public Guid ProjectId { get; set; }

        [Required]
        [StringLength(50)]
        public String Name { get; set; }

        public String Description { get; set; }
        public String Status { get; set; }

        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public List<User> Users { get; set; }
        public List<Section> Sections { get; set; }
    }
}
