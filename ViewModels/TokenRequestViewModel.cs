using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektV3.ViewModels
{
    public class TokenRequestViewModel
    {
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string pesel { get; set; }
        public string password { get; set; }
    }
}
