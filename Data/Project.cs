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

        [StringLength(130)]
        public String Description { get; set; }
        public String Status { get; set; }
        public DateTime EndDate { get; set; } = DateTime.Now;
        public DateTime StartDate { get; set; } = DateTime.Now;

        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
 
        public List<Section> Sections { get; set; }
    }
}
