using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjektV3.Data.Models;

namespace ProjektV3.Data.Repositories
{
    public class RegistrationsRepository : IRegistrationsRepository
    {
        private ApplicationDbContext context;
        public RegistrationsRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }


        public bool AddRegistration(Registration model)
        {
            //int x = context.WorkingHours.Where(p => p.StartWorkingHours.Date == model.Hour.Date).FirstOrDefault().RoomNumber;
            //model.RoomNumber = x;
            var entity = context.Registrations.Where(p => p.Id == model.Id).FirstOrDefault();
            if(entity != null)
            {
                entity.IdPatient = model.IdPatient;
                entity.IsEmpty = false;
                context.Registrations.Update(entity);
            }
            else
            {
                return false;
            }
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

        /*
        public bool AddRegistration(Registration model)
        {
            int x = context.WorkingHours.Where(p => p.StartWorkingHours.Date == model.Hour.Date).FirstOrDefault().RoomNumber;
            model.RoomNumber = x;
            context.Add(model);
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
        */
        // To do robienia przy okazji dodawania working hours
        public bool AddRegistrations(Registration model)
        {
            context.Add(model);
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

        public IQueryable<Registration> ShowRegistrations => context.Registrations;

        public IQueryable<Registration> RegistrationFromDoctors(int id)
        {
            return context.Registrations.Where(p => p.IdDoctor == id && p.IsEmpty == false).OrderBy(a => a.Hour);
        }

        public IQueryable<Registration> RegistrationFromPatientsById(int id)
        {
            return context.Registrations.Where(p => p.IdPatient == id).OrderBy(a => a.Hour);
        }

        public IQueryable<Registration> RegistrationFromPatientsByPesel(string pesel)
        {
            var user = context.Users.Where(p => p.PESEL == pesel).FirstOrDefault();
            if (user == null)
                return null;
            var x = context.Registrations.Where(p => p.IdPatient == user.Id).OrderBy(a => a.Hour);
            return x;
        }

        public bool RemoveRegistration(int id)
        {
            var entity = context.Registrations.Where(p => p.Id == id).FirstOrDefault();
            if (entity == null)
            {
                return false;
            }
            else
            {
                entity.IdPatient = 1;
                entity.IsEmpty = true;
                context.Registrations.Update(entity);
            }
            
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

        public IQueryable<Registration> RegistrationEmptyFromToday()
        {
            var now = DateTime.Today;
            return context.Registrations.Where(p => p.IsEmpty == true && p.Hour >= now).OrderBy(a => a.Hour);
        }

        public IQueryable<Registration> RegistrationEmptyFromTodayByDoctorId(int id)
        {
            var now = DateTime.Today;
            return context.Registrations.Where(p => p.IsEmpty == true && p.Hour >= now && p.IdDoctor == id).OrderBy(a => a.Hour);
        }
    }
}
