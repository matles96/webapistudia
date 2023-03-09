using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektV3.Data.Models
{
    public class WorkingHour
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int IdDoctor { get; set; }
        [Required]
        public EDayOfTheWeek DayOfTheWeek { get; set; }
        [Required]
        public DateTime StartWorkingHours { get; set; }
        [Required]
        public DateTime EndWorkingHours { get; set; }

        [ForeignKey("IdDoctor")]
        public Doctor Doctor { get; set; }

        [Required]
        public int RoomNumber { get; set; }
    }
}
