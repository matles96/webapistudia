using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjektV3.Data.Models;

namespace ProjektV3.Data.Models
{
    public interface IPatientsRepository
    {
        IQueryable<ApplicationUser> Patients { get; }

        IQueryable<ApplicationUser> PatientPesel(string pesel);

        IQueryable<ApplicationUser> PatientId(int id);

        bool AddPatient(ApplicationUser patient);

    }
}
