using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjektV3.Data.Models;
using ProjektV3.ViewModels;

namespace ProjektV3.Data.Repositories
{
    public class DoctorsRepository : IDoctorsRepository
    {
        private ApplicationDbContext context;

        public DoctorsRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Doctor> ShowDoctors => context.Doctors;

        public bool AddDoctor(Doctor doctor)
        {
                context.Add(doctor);
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

        public bool RemoveDoctor(int id)
        {
            var entity = context.Doctors.Where(p => p.Id == id).FirstOrDefault();
            if(entity == null)
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

    }
}
