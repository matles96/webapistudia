using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using ProjektV3.Data;
using ProjektV3.Data.Models;
using ProjektV3.ViewModels;
using Microsoft.EntityFrameworkCore;
using Mapster;
using Microsoft.AspNetCore.Authorization;

namespace ProjektV3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IPatientsRepository repository;

        public ValuesController(IPatientsRepository repo)
        {
            repository = repo;
        }
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [Authorize]
        [HttpGet("{a}/{b}")]
        public ActionResult<IEnumerable<string>> Get(string a, string b)
        {
            return new string[] { "value1", "value200" };
        }

        [HttpGet("{id}")]
        public ActionResult<IQueryable<ApplicationUser>> Get(int id)
        {
            var x = repository.Patients.Where(i => i.Id == id);
            return new JsonResult(x.Adapt<PatientViewModel[]>(), new JsonSerializerSettings() { Formatting = Formatting.Indented });

        }


        [HttpPost]
        public ActionResult<IQueryable<ApplicationUser>> Post([FromBody] int id)
        {
            var x = repository.Patients.Where(i => i.Id == id);
            return new JsonResult(x.Adapt<PatientViewModel[]>(), new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
