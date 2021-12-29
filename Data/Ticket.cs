using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Osiris.Data
{
    public class Ticket
    {
        [Key]
        public Guid TicketId { get; set; }

        [Required]
        [StringLength(50)]
        public String Name { get; set; }

        [Required]
        public String Status { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;

        [StringLength(130)]
        public String Description { get; set; }

        public String AssignedUser { get; set; }

        public Guid ProjectId { get; set; }

        public Guid SectionId { get; set; }
        public Section Section { get; set; }
    }
}
