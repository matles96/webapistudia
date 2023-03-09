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
    public class PatientsController : ControllerBase
    {
        private IPatientsRepository repository;

        public PatientsController(IPatientsRepository repo)
        {
            repository = repo;
        }

        [HttpGet("getPatients")]
        public ActionResult<IQueryable<ApplicationUser>> GetPatients()
        {
            var x = repository.Patients ;
            return new JsonResult(x.Adapt<PatientViewModel[]>(), new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }

        [HttpGet("getPatientsById/{id}")]
        public ActionResult<IQueryable<ApplicationUser>> GetPatientsById(int id)
        {
            var x = repository.PatientId(id);
            if (x == null) { return new BadRequestResult(); }
            return new JsonResult(x.Adapt<PatientViewModel[]>(), new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
        [Authorize]
        [HttpGet("getPatient/logged")]
        public ActionResult<IQueryable<ApplicationUser>> GetPatientsByIdAuthorize()
        {
            var idString = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if(idString == null)
            {
                return new StatusCodeResult(500);
            }
            var id = Int32.Parse(idString);
            var x = repository.PatientId(id);
            if (x == null) { return new BadRequestResult(); }
            return new JsonResult(x.Adapt<PatientViewModel[]>(), new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }

        [HttpGet("getPatientsByPesel/{pesel}")]
        public ActionResult<IQueryable<ApplicationUser>> GetPatientsByPesel(string pesel)
        {
            var x = repository.PatientPesel(pesel);
            if (x == null) { return new BadRequestResult(); }
            return new JsonResult(x.Adapt<PatientViewModel[]>(), new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }

        [HttpPost("addPatient")]
        public IActionResult Post([FromBody] PatientViewModel patientViewModel)
        {
            if (patientViewModel == null)
            {
                return new StatusCodeResult(500);
            }
            if (patientViewModel.Name.Length == 0 || patientViewModel.LastName.Length == 0 || patientViewModel.PESEL.Length != 11 || patientViewModel.PhoneNumber.Length == 0 || patientViewModel.Password.Length < 6)
            {
                return new StatusCodeResult(500);
            }
            var model = patientViewModel.Adapt<ApplicationUser>();
            bool response = repository.AddPatient(model);

            if (response)
            {
                return Ok(patientViewModel);
            }
            else
            {
                return new BadRequestResult();
            }
        }

    }
}