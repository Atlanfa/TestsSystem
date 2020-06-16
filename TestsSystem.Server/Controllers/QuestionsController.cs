using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using TestsSystem.Business.Contracts;
using TestsSystem.Core.DTO;
using TestsSystem.Core.Models.Server.Answers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestsSystem.Server.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IServQuestions _servQuestions;

        public QuestionsController(
            IServQuestions servQuestions)
        {
            _servQuestions = servQuestions;
        }

        // GET: api/<QuestionsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                int id = int.Parse(Request.Query["questId"].ToString());
                return Ok(await _servQuestions.GetQuestionAsync(id));

            }
            catch (Exception ex)
            {
                return Ok(new AnswerFail
                {
                    Reason = ex.Message
                });
            }
        }

        // GET api/<QuestionsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
            => Ok(await _servQuestions.GetQuestionsAsync(id));

        // POST api/<QuestionsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DtoCreateQuestion dto)
            => Ok(await _servQuestions.CreateQuestionAsync(dto));

        // PUT api/<QuestionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<QuestionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
