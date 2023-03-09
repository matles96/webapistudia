using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProjektV3.Data.Models;

namespace ProjektV3.ViewModels
{
    [JsonObject(MemberSerialization.OptOut)]
    public class DoctorViewModel
    {       
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public virtual List<WorkingHour> WorkingHours { get; set; }
        public virtual List<Registration> Registrations { get; set; }
    }
}
