using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProjektV3.Data.Models;

namespace ProjektV3.ViewModels
{
    [JsonObject(MemberSerialization.OptOut)]
    public class WorkingHoursViewModel
    {
        
        public string Id { get; set; }        
        public string IdDoctor { get; set; }        
        public EDayOfTheWeek DayOfTheWeek { get; set; }        
        public DateTime StartWorkingHours { get; set; }        
        public DateTime EndWorkingHours { get; set; }
        public int RoomNumber { get; set; }
        public Doctor Doctor { get; set; }
    }
}
