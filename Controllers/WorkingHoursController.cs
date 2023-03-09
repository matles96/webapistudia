using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using ProjektV3.Data;
using ProjektV3.Data.Models;
using ProjektV3.Data.Repositories;
using ProjektV3.ViewModels;
using Microsoft.EntityFrameworkCore;
using Mapster;

namespace ProjektV3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingHoursController : ControllerBase
    {
        private IWorkingHoursRepository repository;
        
        public WorkingHoursController(IWorkingHoursRepository repo)
        {
            repository = repo;
        }

        [HttpGet("fromToday/{doctorId}")]
        public ActionResult<IQueryable<WorkingHour>> Get(int doctorId)
        {
            var x = repository.WorkingHoursFromToday(doctorId);
            return new JsonResult(x.Adapt<WorkingHoursViewModel[]>(), new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }

        [HttpGet("byDoctorId/all/{doctorId}")]
        public ActionResult<IQueryable<WorkingHour>> GetByDoctorIdAll(int doctorId)
        {
            var x = repository.WorkingHoursAll(doctorId);
            return new JsonResult(x.Adapt<WorkingHoursViewModel[]>(), new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
        [HttpGet("dev/all")]
        public ActionResult<IQueryable<WorkingHour>> Get()
        {
            var x = repository.ShowWorkingHours;
            return new JsonResult(x.Adapt<WorkingHoursViewModel[]>(), new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
        [HttpPost("addWorkingHour")]
        public ActionResult PostAdd([FromBody] WorkingHoursViewModel workingHoursViewModel)
        {
            if(workingHoursViewModel == null)
            {
                return new StatusCodeResult(500);
            }
            var model = workingHoursViewModel.Adapt<WorkingHour>();
            bool response = repository.AddWorkingHours(model);
            if (response)
            {
                return Ok(workingHoursViewModel);
            }
            else
            {
                return new BadRequestResult();
            }
        }
        [HttpPost("removeWorkingHour")]
        public ActionResult PostRemove([FromBody] IdVM id)
        {
            if (id.Id.ToString() == null)
            {
                return new StatusCodeResult(500);
            }
            bool response = repository.RemoveWorkingHour(id.Id);
            if (response)
            {
                return Ok("done");
            }
            else
            {
                return new BadRequestResult();
            }
        }
    }
}