using System;
using System.ComponentModel.DataAnnotations;

namespace Osiris.Data
{
    public class Company
    {
        [Key]
        public Guid CompanyId { get; set; }

        [Required]
        public String Name { get; set; }

        public String Description { get; set; }
    }
}
