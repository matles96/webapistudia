using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjektV3.Data.Models;
using ProjektV3.ViewModels;

namespace ProjektV3.Data.Repositories
{
    public interface IDoctorsRepository
    {
        IQueryable<Doctor> ShowDoctors { get; }
        bool AddDoctor(Doctor doctor);
        bool RemoveDoctor(int id);
        
    }
}
