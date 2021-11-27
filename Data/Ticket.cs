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
        public String Status { get; set; }
        public String Description { get; set; }

        public List<User> User { get; set; }
    }
}
