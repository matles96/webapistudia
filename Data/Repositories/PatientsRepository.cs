using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjektV3.Data.Models;

namespace ProjektV3.Data.Models
{
    public class PatientsRepository : IPatientsRepository
    {
        private ApplicationDbContext context;

        public PatientsRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<ApplicationUser> Patients => context.Users;

        public IQueryable<ApplicationUser> PatientPesel(string pesel)
        {
            return context.Users.Where(p => p.PESEL == pesel);
        }

        public IQueryable<ApplicationUser> PatientId(int id)
        {
            return context.Users.Where(p => p.Id == id);
        }

        public bool AddPatient(ApplicationUser patient)
        {

                context.Add(patient);
                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch (DbUpdateException e)
                {
                    return false;
                }
        }
    }
}
