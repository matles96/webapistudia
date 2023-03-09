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
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ProjektV3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        private IRegistrationsRepository repository;

        public RegistrationsController(IRegistrationsRepository repo)
        {
            repository = repo;
        }
        [HttpGet("get/bydoctor/{id}")]
        public ActionResult<IQueryable<Registration>> GetDoctor(int id)
        {
            var x = repository.RegistrationFromDoctors(id);
            return new JsonResult(x.Adapt<RegistrationViewModel[]>(), new JsonSerializerSettings() { Formatting = Formatting.Indented });     
        }

        [HttpGet("get/empty")]
        public ActionResult<IQueryable<Registration>> GetEmpty()
        {
            var x = repository.RegistrationEmptyFromToday();
            return new JsonResult(x.Adapt<RegistrationViewModel[]>(), new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }

        [HttpGet("get/empty/{id}")]
        public ActionResult<IQueryable<Registration>> GetEmptyId(int id)
        {
            var x = repository.RegistrationEmptyFromTodayByDoctorId(id);
            return new JsonResult(x.Adapt<RegistrationViewModel[]>(), new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }

        [HttpGet("dev/all")]
        public ActionResult<IQueryable<Registration>> Get()
        {
            var x = repository.ShowRegistrations;
            return new JsonResult(x.Adapt<RegistrationViewModel[]>(), new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }

        [Authorize]
        [HttpGet("get/bypatientid/logged")]
        public ActionResult<IQueryable<Registration>> GetPatientIdLogged()
        {
            var idString = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (idString == null)
            {
                return new StatusCodeResult(500);
            }
            var id = Int32.Parse(idString);
            var x = repository.RegistrationFromPatientsById(id);
            return new JsonResult(x.Adapt<RegistrationViewModel[]>(), new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }

        [HttpGet("get/bypatientid/{id}")]
        public ActionResult<IQueryable<Registration>> GetPatientId(int id)
        {
            var x = repository.RegistrationFromPatientsById(id);
            return new JsonResult(x.Adapt<RegistrationViewModel[]>(), new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }

        [HttpGet("get/bypatientpesel/{pesel}")]
        public ActionResult<IQueryable<Registration>> GetPatientPesel(string pesel)
        {
            var x = repository.RegistrationFromPatientsByPesel(pesel);
            return new JsonResult(x.Adapt<RegistrationViewModel[]>(), new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }

        [HttpPost("add/bypatientid")]
        public ActionResult<IQueryable<Registration>> PostPatient([FromBody] AddRegistrationViewModel addRegistration)
        {
            if (addRegistration == null)
            {
                return new StatusCodeResult(500);
            }
            var model = addRegistration.Adapt<Registration>();
            if (model.IdPatient.ToString() == null || model.Id.ToString() == null)
                return new StatusCodeResult(500);

            bool response = repository.AddRegistration(model);
            if (response)
            {
                return Ok(addRegistration);
            }
            else
            {
                return new BadRequestResult();
            }
        }


        [Authorize]
        [HttpPost("add/logged")]
        public ActionResult<IQueryable<Registration>> PostLogged([FromBody] IdVM id)
        {
            if (id == null)
            {
                return new StatusCodeResult(500);
            }
            var IdPatient_ = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            AddRegistrationViewModel registrationVM = new AddRegistrationViewModel()
            {
                Id = id.Id,
                IdPatient = Int32.Parse(IdPatient_)
            };
            var model = registrationVM.Adapt<Registration>();
            if (model.IdPatient.ToString() == null || model.Id.ToString() == null)
                return new StatusCodeResult(500);
            bool response = repository.AddRegistration(model);
            if (response)
            {
                return Ok(id);
            }
            else
            {
                return new BadRequestResult();
            }
        }

        [HttpPost("remove")]
        public ActionResult<IQueryable<Registration>> PostRemove([FromBody] IdVM id)
        {
            if (id.Id.ToString() == null)
            {
                return new StatusCodeResult(500);
            }
            bool response = repository.RemoveRegistration(id.Id);
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