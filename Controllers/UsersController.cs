using CrudUser.Application.Interfaces;
using CrudUser.Domain.Entities;
using CrudUser.Domain.Extensions.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudUsers.Api.Controllers
{
    /// <summary>
    ///     Manages users information.
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController :  ControllerBase
    {
        private readonly IUserAppService _userAppService;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="userAppService"></param>
        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(IEnumerable<User>), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 401)]
        [ProducesResponseType(typeof(Error), 403)]
        [ProducesResponseType(typeof(Error), 500)]
        public async Task<IEnumerable<User>> GetAll()
        {
            var response = await _userAppService.GetAll();
            return (IEnumerable<User>)Ok(response);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(IList<User>), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 401)]
        [ProducesResponseType(typeof(Error), 403)]
        [ProducesResponseType(typeof(Error), 500)]
        public async Task<IActionResult> Patch([FromRoute] int id, [FromBody] User user)
        {
            await _userAppService.Update(id, user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(IList<User>), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 401)]
        [ProducesResponseType(typeof(Error), 403)]
        [ProducesResponseType(typeof(Error), 500)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _userAppService.Delete(id);
            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 401)]
        [ProducesResponseType(typeof(Error), 403)]
        [ProducesResponseType(typeof(Error), 500)]
        public async Task<IActionResult> Post([FromBody] User user)
        {

           await _userAppService.Post(user);
            return NoContent();
        }
    }
}
