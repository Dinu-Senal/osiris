using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Osiris.Data
{
    public class Section
    {
        [Key]
        public Guid SectionId { get; set; }

        [Required]
        public String Name { get; set; }

        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        public List<Ticket> Tickets { get; set; }
    }
}
