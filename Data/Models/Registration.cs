using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektV3.Data.Models
{
    public class Registration
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int IdDoctor { get; set; }
        [Required]
        public int IdPatient { get; set; }
        [ForeignKey("IdDoctor")]
        public Doctor Doctor { get; set; }
        [ForeignKey("IdPatient")]
        public virtual ApplicationUser User { get; set; }
        [Required]
        public DateTime Hour { get; set; }
        [Required]
        public int RoomNumber {get; set;}
        [Required]
        public bool IsEmpty { get; set; }
    }
}
