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
        public String Name { get; set; }

        [Required]
        public String Status { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;

        public String Description { get; set; }

        public Guid SectionId { get; set; }
        public Section Section { get; set; }

        public List<User> User { get; set; }
    }
}
