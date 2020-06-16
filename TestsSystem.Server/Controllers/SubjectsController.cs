using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using TestsSystem.Business.Contracts;
using TestsSystem.Core.DTO;

namespace TestsSystem.Server.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly IServSubjects _servSubjects;

        public SubjectsController(
            IServSubjects servSubjects)
        {
            _servSubjects = servSubjects;
        }

        // GET: api/<SubjectsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SubjectsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
            => Ok(await _servSubjects.GetSubjectsAsync(id));

        // POST api/<SubjectsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DtoCreateSubject dto)
            => Ok(await _servSubjects.CreateSubjectAsync(dto));

        // PUT api/<SubjectsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SubjectsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
