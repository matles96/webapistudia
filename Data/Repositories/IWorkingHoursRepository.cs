using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjektV3.Data.Models;

namespace ProjektV3.Data.Repositories
{
    public interface IWorkingHoursRepository
    {
        IQueryable<WorkingHour> WorkingHoursAll(int id);
        IQueryable<WorkingHour> WorkingHoursFromToday(int id);

        bool AddWorkingHours(WorkingHour wh);
        bool RemoveWorkingHour(int id);
        IQueryable<WorkingHour> ShowWorkingHours { get; }
    }
}
