using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjektV3.Data.Models;

namespace ProjektV3.Data.Repositories
{
    public class WorkingHoursRepository : IWorkingHoursRepository
    {
        private ApplicationDbContext context;
        private IRegistrationsRepository registrations;
        public WorkingHoursRepository(ApplicationDbContext ctx, IRegistrationsRepository reg)
        {
            context = ctx;
            registrations = reg;
        }

        public bool AddWorkingHours(WorkingHour wh)
        {
            
            var start = wh.StartWorkingHours;
            var end = wh.EndWorkingHours;
            
            while (start < end)
            {
                var x = new Registration()
                {
                    IdDoctor = wh.IdDoctor,
                    IdPatient = 1,
                    IsEmpty = true,
                    RoomNumber = wh.RoomNumber,
                    Hour = start

                };
                start = start.AddMinutes(15);
                if (!registrations.AddRegistrations(x))
                {
                    start = end;
                }

            }
            
            context.WorkingHours.Add(wh);
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

        public bool RemoveWorkingHour(int id)
        {
            var entity = context.WorkingHours.Where(p => p.Id == id).FirstOrDefault();
            if (entity == null)
            {
                return false;
            }
            context.Remove(entity);
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

        public IQueryable<WorkingHour> WorkingHoursFromToday(int id) {
            var now = DateTime.Today;
            return context.WorkingHours.Where(p => p.IdDoctor == id && p.StartWorkingHours >= now);
        }
        public IQueryable<WorkingHour> WorkingHoursAll(int id)
        {
            var now = DateTime.Today;
            return context.WorkingHours.Where(p => p.IdDoctor == id);
        }


        public IQueryable<WorkingHour> ShowWorkingHours => context.WorkingHours;
    }
}
