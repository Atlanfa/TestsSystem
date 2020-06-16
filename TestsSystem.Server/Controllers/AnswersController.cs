using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using TestsSystem.Business.Contracts;
using TestsSystem.Core.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestsSystem.Server.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly IServAnswers _servAnswers;

        public AnswersController(
            IServAnswers servAnswers)
        {
            _servAnswers = servAnswers;
        }

        // GET: api/<AnswersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AnswersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
            => Ok(await _servAnswers.GetAnswersAsync(id));

        // POST api/<AnswersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<DtoCreateAnswer> answers)
            => Ok(await _servAnswers.AddIssuedAnswersAsync(answers));

        // PUT api/<AnswersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DtoAnswer answer)
            => Ok(await _servAnswers.UpdateAnswerAsync(id, answer));

        // DELETE api/<AnswersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
