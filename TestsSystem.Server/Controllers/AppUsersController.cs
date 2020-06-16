using Microsoft.AspNetCore.Mvc;

using System;
using System.Threading.Tasks;

using TestsSystem.Business.Contracts;
using TestsSystem.Core.DTO;
using TestsSystem.Core.Enums;
using TestsSystem.Core.Models.Server.Answers;

namespace TestsSystem.Server.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly IServAppUsers _appUsers;

        public AppUsersController(
            IServAppUsers appUsers)
        {
            _appUsers = appUsers;
        }

        [HttpGet("{role}")]
        public async Task<IActionResult> Get(EUserRole role)
        {
            try
            {
                return Ok(await _appUsers.GetAppUsersAsync(role));
            }
            catch (Exception ex)
            {
                return Ok(new AnswerFail
                {
                    Reason = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DtoQuery query)
        {
            try
            {
                return Ok(await _appUsers.GetAppUserAsync(query.Role, query.Id, query.Email));
            }
            catch (Exception ex)
            {
                return Ok(new AnswerFail
                {
                    Reason = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DtoAppUser appUser)
        {
            try
            {
                await _appUsers.CreateAppUserAsync(appUser);
                return Ok(new AnswerSuccess { });
            }
            catch (Exception ex)
            {
                return Ok(new AnswerFail
                {
                    Reason = ex.Message
                });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DtoAppUser appUser)
        {
            try
            {
                await _appUsers.UpdateAppUserAsync(appUser);
                return Ok(new AnswerSuccess { });
            }
            catch (Exception ex)
            {
                return Ok(new AnswerFail
                {
                    Reason = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromQuery] DtoQuery query)
        {
            try
            {
                await _appUsers.DeleteAppUserAsync(id, query.Role);
                return Ok(new AnswerSuccess { });
            }
            catch (Exception ex)
            {
                return Ok(new AnswerFail
                {
                    Reason = ex.Message
                });
            }
        }
    }
}
