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
    public class DoctorsController : ControllerBase
    {
        private IDoctorsRepository repository;

        public DoctorsController(IDoctorsRepository repo)
        {
            repository = repo;
        }

        [HttpGet("getDoctors")]
        public ActionResult<IQueryable<ApplicationUser>> Get()
        {
            var x = repository.ShowDoctors;
            return new JsonResult(x.Adapt<DoctorViewModel[]>(), new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }

        [HttpPost("addDoctor")]
        public IActionResult Post([FromBody] DoctorViewModel doctorViewModel)
        {
           
            if (doctorViewModel == null)
            {
                return new StatusCodeResult(500);
            }

            if (doctorViewModel.Name.Length == 0 || doctorViewModel.LastName.Length == 0 || doctorViewModel.PhoneNumber.Length == 0)
            {
                return new StatusCodeResult(500);
            }

            var model = doctorViewModel.Adapt<Doctor>();
            bool response = repository.AddDoctor(model);

            if (response)
            {
                return Ok(doctorViewModel);
            }
            else
            {
                return new BadRequestResult();
            }
        }

        [HttpPost("removeDoctor")]
        public IActionResult PostRemove([FromBody] IdVM idvm)
        {
            if (idvm.Id.ToString() == null)
            {
                return new StatusCodeResult(500);
            }

            bool response = repository.RemoveDoctor(idvm.Id);
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