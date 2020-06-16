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
    public class ThemesController : ControllerBase
    {
        private readonly IServThemes _servThemes;

        public ThemesController(
            IServThemes servThemes)
        {
            _servThemes = servThemes;
        }

        // GET: api/<ThemesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ThemesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
            => Ok(await _servThemes.GetThemesAsync(id));

        // POST api/<ThemesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DtoCreateTheme dto)
            => Ok(await _servThemes.CreateThemeAsync(dto));

        // PUT api/<ThemesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ThemesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
