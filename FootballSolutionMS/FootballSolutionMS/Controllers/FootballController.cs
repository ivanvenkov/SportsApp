using Domain.Application;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballSolutionMS.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Produces("application/json")]
    public class FootballController : Controller
    {
        private readonly IPersonManager personManager;
        
        public FootballController(IPersonManager personManager)
        {
            this.personManager = personManager;
        }
        [HttpGet]
        public async Task<IEnumerable<PersonVM>> Get()
        {
            var result = await this.personManager.GetPersonsAsync();
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddNewFootballer([FromBody] PersonVM footballer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newFootballerId = await this.personManager.AddNewPersonAsync(footballer);
                return Ok(newFootballerId);
            }
            catch (ArgumentException ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.personManager.DeleteAsync(id);
            return Ok();
        }
    }
}