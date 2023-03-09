using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ProjektV3.Data.Models
{
    public class ApplicationUser
    {  
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string PESEL { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public virtual List<Registration> Registrations { get; set; }
    }
}
