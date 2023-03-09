using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProjektV3.Data.Models;

namespace ProjektV3.ViewModels
{
    [JsonObject(MemberSerialization.OptOut)]
    public class RegistrationViewModel
    {
        public string Id { get; set; }
        public string IdDoctor { get; set; }
        public string IdPatient { get; set; }
        public Doctor Doctor { get; set; }
        public int RoomNumber { get; set; }
        public ApplicationUser Patient { get; set; }
        public DateTime Hour { get; set; }
        public bool IsEmpty { get; set; }
    }
}
