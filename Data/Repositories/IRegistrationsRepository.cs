using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjektV3.Data.Models;

namespace ProjektV3.Data.Repositories
{
    public interface IRegistrationsRepository
    {
        IQueryable<Registration> RegistrationFromPatientsById(int id);
        IQueryable<Registration> RegistrationFromDoctors(int id);
        IQueryable<Registration> RegistrationEmptyFromToday();
        IQueryable<Registration> RegistrationEmptyFromTodayByDoctorId(int id);
        IQueryable<Registration> RegistrationFromPatientsByPesel(string pesel);
        bool AddRegistration(Registration model);
        bool AddRegistrations(Registration model);
        bool RemoveRegistration(int id);
        IQueryable<Registration> ShowRegistrations { get; }
    }
}
